using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Storage : Building {

    [Serializable]
    public struct StoreInfo {  
        public ResourceType resourceType;
        public float storeAmount;

        public StoreInfo(ResourceType resourceType, float storeAmount) {
            this.resourceType = resourceType;
            this.storeAmount = storeAmount;
        }
    }
    [Header("Storage")]
    [Space(10f), SerializeField] private List<StoreInfo> storeInfos;
    
    



    public override void SetupBuilding() {
    
        status = GameManager.Instance.BuildingStatus[_buildingIndex];

        gameObject.name = status.name;
        _size = status.size;
        buildPrice = status.buildPrice;
        buildMinute = status.buildMinute;
        
        storeInfos.Clear();
        for (int i = 0; i < status.itemTypes.Count; i++) {
            storeInfos.Add(new StoreInfo(status.itemTypes[i], default));
        }
    }
    
    public override void Select() {}

}
