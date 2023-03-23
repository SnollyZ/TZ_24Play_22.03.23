using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float JUMP_HEIGHT = 0.5f;
    private const float LEFT_MOVE_BORDER = 1.98f;
    private const float RIGHT_MOVE_BORDER = -1.98f;

    private Transform stickman;
    private GameObject stickmanObj;
    private GameObject ragdoll;
    private Animator animator;
    private Rigidbody rigidbody;
    
    void Start()
    {
        stickman = transform.GetChild(0);
        stickmanObj = stickman.gameObject;
        ragdoll = transform.GetChild(1).gameObject;
        animator = stickman.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckBorders();
    }

    public void Jump(Vector3 topCubePos){
        Vector3 point = new Vector3(topCubePos.x, topCubePos.y + JUMP_HEIGHT, topCubePos.z);
        stickman.transform.position = point;
        StickmanFixPosition();
        animator.SetTrigger("Jump");
    }

    public void MovePlayer(Vector3 moveDirection){
        rigidbody.velocity = moveDirection;
    }

    private void CheckBorders(){
        Vector3 currentPos = transform.position;
        if(currentPos.x > LEFT_MOVE_BORDER || currentPos.x < LEFT_MOVE_BORDER){
            float xPos = Mathf.Clamp(currentPos.x, RIGHT_MOVE_BORDER, LEFT_MOVE_BORDER);
            Vector3 position = new Vector3(xPos, currentPos.y, currentPos.z);
            transform.position = position;
        }
    }

    public void Death(){
        StopMove();
        stickmanObj.SetActive(false);
        ragdoll.SetActive(true);
        ragdoll.transform.position = stickman.position;
    }

    private void StopMove(){
        rigidbody.constraints = RigidbodyConstraints.FreezePosition;
    }

    private void StickmanFixPosition(){
        Transform stickmanTransform = stickman.transform;
        Vector3 newPosition = new Vector3(0, stickmanTransform.localPosition.y, 0);
        stickmanTransform.localPosition = newPosition;
    }
}
