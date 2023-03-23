using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField]private float smoothSpeed = 0.5f;
    [SerializeField]private Vector3 offset;
    [SerializeField]private Quaternion rotationOffset;
    
    private Vector3 startPosition;
    private Coroutine chase;

    private void Start() {
        transform.rotation = rotationOffset;
        startPosition = target.position + offset;
        transform.position = startPosition;
        chase = StartCoroutine(Chase());
    }

    private IEnumerator Chase(){
        while(true){
            if(target != null){
                Vector3 desiredPosition = new Vector3(startPosition.x, startPosition.y , target.position.z) + offset;
                transform.position = desiredPosition;
            }
            else
                Debug.Log("Camera: Can't find player");

            yield return null;
        }
    }

    public void StopChasing(){
        StopCoroutine(chase);
    }
}
