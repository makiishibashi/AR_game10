using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform camra;

    // Start is called before the first frame update
    void Start()
    {
        this.camra = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var cameraPosition = this.camra.position;
        cameraPosition.y = this.transform.position.y;
        this.transform.LookAt(cameraPosition);
    }
}
