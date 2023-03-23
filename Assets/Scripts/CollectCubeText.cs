using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCubeText : MonoBehaviour
{
    [SerializeField]private GameObject collectCubeTextObj;

    private const float TEXT_DIR_Y = 8f;
    private float moveDuration = 5f;

    public void CallCollectCubeText(){
        StartCoroutine(CollectCubeTextCoroutine());
    }

    private IEnumerator CollectCubeTextCoroutine(){
        GameObject collectCubeText = Instantiate(collectCubeTextObj, transform.position, transform.rotation);
        RectTransform rectTransform = collectCubeText.GetComponent<RectTransform>();
        Vector3 rectTransformPos = rectTransform.position;
        float dir = rectTransformPos.y + TEXT_DIR_Y;
        float moveTime = 0;
        while(moveTime < moveDuration){
            float newPositionY = Mathf.Lerp(rectTransformPos.y, dir, (moveTime / moveDuration));
            moveTime += Time.deltaTime;
            rectTransform.position = new Vector3(rectTransformPos.x, newPositionY, rectTransformPos.z);
            yield return null;
        }
        yield break;
    }
}
