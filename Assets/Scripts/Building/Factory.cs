using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Building {

    [SerializeField] private float holdResourceAmount;
    [Header("Status")]
    [SerializeField] private float collectPerSecond;
    [SerializeField] private float maxCollect;

    [Space(10f)]
    [SerializeField] private ResourceType _resourceType;



    private void ColletBySleepTime(int sleepTime) {

        holdResourceAmount = collectPerSecond * sleepTime;
        holdResourceAmount = Mathf.Clamp(holdResourceAmount, 0, maxCollect);
    }


    private void GetResource() {
        
//        GameManager.Instance.자원 += 뭐시기
    }
    
}
