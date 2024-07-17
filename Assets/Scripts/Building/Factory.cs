using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Factory : Building {
    
    [Header("Factory")]
    [SerializeField] private int holdResourceAmount;
    [Space(5)]
    [SerializeField] private float collectPerHour;

    [Space(10f)]
    [SerializeField] private ResourceType _resourceType;



    public override void SetupBuilding() {

        status = GameManager.Instance.BuildingStatus[_buildingIndex];


        gameObject.name = status.name;
        _size = status.size;
        buildPrice = status.buildPrice;
        buildMinute = status.buildMinute;
        
        _resourceType = status.itemTypes[0];
        
        SetCollect();
    }
    
    
    public override void Select() {

        if (holdResourceAmount > 0) UIManager.Instance.OnClickBuilding();
    }
    

    private void SetCollect() {
        
        foreach (ItemStatus.ItemStat stat in GameManager.Instance.ItemStatus) {
            if (_resourceType == stat.type) {

                collectPerHour = stat.collectAmountHour;
                break;
            }
        }
    }

    private void ColletBySleepTime(int sleepTime) {

        holdResourceAmount = (int)collectPerHour * sleepTime;
    }


    private void GetResource() {
        
        switch (_resourceType) {
            
            case (ResourceType.Rices):
                GameManager.Instance.SaveData.Rices += holdResourceAmount;
                Debug.Log(GameManager.Instance.SaveData.Rices);
                break;
            
            case (ResourceType.Corns):
                GameManager.Instance.SaveData.Corns += holdResourceAmount;
                break;
            
            case (ResourceType.Potatoes):
                GameManager.Instance.SaveData.Potatoes += holdResourceAmount;
                break;
        }
    }
    
}
