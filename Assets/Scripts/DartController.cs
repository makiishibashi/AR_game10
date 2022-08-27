using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DartController : MonoBehaviour
{
    public static DartController instance;
    public GameObject DartPrefab;
    public Transform DartThrowPoint;
    ARSessionOrigin aRSession;
    GameObject ARCam;
    private GameObject DartTemp;
    private Rigidbody rb;
  

    void Start()
    {
        aRSession = GameObject.Find("AR Session Origin").GetComponent<ARSessionOrigin>();
        ARCam = aRSession.transform.Find("AR Camera").gameObject;

        
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DartsInit();
    }
    

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.CompareTag("dart"))
                {
                    //Dislabe back touch Collider from dart
                    raycastHit.collider.enabled = false;

                    DartTemp.transform.parent = aRSession.transform;

                    Dart currentDartScript = DartTemp.GetComponent<Dart>();
                    currentDartScript.isForceOK = true;

                    ///Load next dart
                    DartsInit();
                }
            }
        }
    }
    
    /// <summary>
    /// ダーツを出す処理です
    /// </summary>
    void DartsInit()
    {
        StartCoroutine(WaitAndSpawnDart());
    }

    public IEnumerator WaitAndSpawnDart()
    {
        yield return new WaitForSeconds(0.1f);
        DartTemp = Instantiate(DartPrefab, DartThrowPoint.position, ARCam.transform.localRotation);
        DartTemp.transform.parent = ARCam.transform;
        rb = DartTemp.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
}

