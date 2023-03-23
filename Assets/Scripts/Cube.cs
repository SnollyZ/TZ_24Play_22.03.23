using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private const float CUBE_HEIGHT_MODIFIER = 1f;

    private Collider cubeCollider;
    private TowerManager towerManager;
    private bool hasBeenHitted = false;

    void Start(){
        cubeCollider = GetComponent<Collider>();
        towerManager = TowerManager.instance;
    }

    public void AddCubeToTower(Collider otherCollider){
        transform.parent = otherCollider.transform;
        IgnoreCollision(otherCollider);
        MoveCubeToTower();
        towerManager.AddCubeToTower(transform, this);
    }

    public void IgnoreCollision(Collider otherCollider){
        Physics.IgnoreCollision(cubeCollider, otherCollider);
    }

    private void MoveCubeToTower(){
        Vector3 topCubePos = towerManager.GetTopCubePos();
        Vector3 point = new Vector3(topCubePos.x, topCubePos.y + CUBE_HEIGHT_MODIFIER, topCubePos.z);
        transform.position = point;
    }

    public void MoveCube(Transform player){
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "Wall"){
            RaycastHit hit;
            Vector3 dir = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.6f);
            if(Physics.Linecast(transform.position, dir, out hit))
            {
                if(other.transform.tag == hit.transform.tag && !hasBeenHitted)
                {
                    WallCollision();
                }
            }
        }
    }

    private void WallCollision(){
        Handheld.Vibrate();
        hasBeenHitted = true;
        transform.parent = null;
        towerManager.RemoveCubeFromLists(transform, this);
    }
}
