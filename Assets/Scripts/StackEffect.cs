using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackEffect : MonoBehaviour
{

    private const float STACK_EFFECT_TIME = 0.5F;

    private Coroutine currentStackEffect;
    private GameObject stackEffectObj;
    
    void Start(){
        stackEffectObj = transform.GetChild(0).gameObject;
    }

    public void CallStackEffect(){
        if(currentStackEffect != null)
            {
                StopCoroutine(currentStackEffect);
                stackEffectObj.SetActive(false);
            }
        currentStackEffect = StartCoroutine(StackEffectCoroutine());
    }

    private IEnumerator StackEffectCoroutine()
    {
        stackEffectObj.SetActive(true);
        yield return new WaitForSeconds(STACK_EFFECT_TIME);
        stackEffectObj.SetActive(false);
        yield break;
    }
}
