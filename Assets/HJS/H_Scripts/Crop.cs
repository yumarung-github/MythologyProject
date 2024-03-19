using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    //작물 -> 이름, 성장속도, 판매가, 구입가?

    [SerializeField] protected string cropName;
    [SerializeField] protected float cropGrowTime;
    [SerializeField] protected float cropSell;
    [SerializeField] protected float cropBuy;

    protected virtual void OnEnable() => StartCoroutine(GrowCo(cropGrowTime));


    protected IEnumerator GrowCo(float growTime)
    {
        float time = 0;
        while(time <= growTime)
        {
            yield return new WaitForSeconds(1);
            time += 1;
        }
        yield return null;
    }

}
