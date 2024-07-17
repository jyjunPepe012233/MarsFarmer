using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Building {
    
    [Header("Factory")]
    [SerializeField] private float holdResourceAmount;
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

    private void SetCollect() {
        
        foreach (ItemStatus.ItemStat stat in GameManager.Instance.ItemStatus) {
            if (_resourceType == stat.type) {

                collectPerHour = stat.collectAmountHour;
                break;
            }
        }
    }

    private void ColletBySleepTime(int sleepTime) {

        holdResourceAmount = collectPerHour * sleepTime;
    }
    


    private void GetResource() {

        switch (_resourceType) {
            
            case (ResourceType.Rices):
                break;
            
            case (ResourceType.Corns):
                break;
            
            case (ResourceType.Potatoes):
                break;
        }
    }
    
}
