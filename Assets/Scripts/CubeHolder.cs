using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHolder : MonoBehaviour
{
    private Collider collider;

    void Start()
    {
        collider = GetComponent<Collider>();
        transform.GetChild(0).GetComponent<Cube>().IgnoreCollision(collider);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Cube"){
            other.GetComponent<Cube>().AddCubeToTower(collider);
        }
    }
}
