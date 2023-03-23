using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private GameManager gameManager;

    private void Start(){
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Wall" || other.tag == "TrackGround"){
            gameManager.EndGame();
        }
    }
}
