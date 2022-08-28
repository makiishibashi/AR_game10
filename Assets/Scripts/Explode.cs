using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosion;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Cube")
        {
            Destroy(collision.transform.gameObject);//Destroy Cube
            Scoring.score += 1;
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
        }   
    }
}
