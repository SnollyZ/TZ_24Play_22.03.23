using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float direction;
    private TowerManager towerManager;

    void Start(){
        towerManager = TowerManager.instance;
    }
    
    void Update()
    {
        if(Input.GetMouseButton(0)){
            direction = -Input.GetAxis("Mouse X");
        }
        else{
            direction = 0f;
        }
        towerManager.MoveTower(direction);
    }
}
