using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private LevelGenerator levelGenerator;
    
    void Start(){
        levelGenerator = LevelGenerator.instance;
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            Vector3 parentPos = transform.parent.position;
            levelGenerator.GenerateNewTrackObject(parentPos);
        }
    }
}
