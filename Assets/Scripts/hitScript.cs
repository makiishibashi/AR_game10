using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        PlaceObjectOnPlane.instance.isObjectPlaced = false;
        //PlaceObjectOnPlane placeObjectOnPlane = new PlaceObjectOnPlane();
        //placeObjectOnPlane.x = true;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
