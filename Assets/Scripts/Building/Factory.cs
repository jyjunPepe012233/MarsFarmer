using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Factory : Building {
    
    [Header("Factory")]
    [SerializeField] private int holdResourceAmount;
    [Space(5)]
    [SerializeField] private float collectPerHour;

    [Space(10f)]
    [SerializeField] private ResourceType _resourceType;

    [SerializeField] private GameObject curPopUp;

    private float collectTemp;


    void Update() {

        if (holdResourceAmount > 0) {
            
            if (curPopUp == null)
                curPopUp = Instantiate( GameManager.Instance.ItemStatus[(int)_resourceType].popUp,
                                        UIManager.Instance.popUpParent );

            curPopUp.GetComponent<RectTransform>().position =
                CameraManager.Instance.camData.WorldToScreenPoint(transform.position) + new Vector3(0, 0, 200);
        }

        Collect();

    }

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

        if (holdResourceAmount > 0) {
            GetResource();
        }
    }
    

    private void SetCollect() {
        
        foreach (ItemStatus.ItemStat stat in GameManager.Instance.ItemStatus) {
            if (_resourceType == stat.type) {

                collectPerHour = stat.collectAmountHour;
                break;
            }
        }
    }

    private void Collect() {

        collectTemp += Time.deltaTime * (collectPerHour / 60 / 60);
        if (collectTemp >= 1) {
            collectTemp = 0;
            holdResourceAmount += 1;
        }
        
    }


    private void GetResource() {
        
        switch (_resourceType) {
            
            case (ResourceType.Rices):
                GameManager.Instance.SaveData.Rices += holdResourceAmount;
                holdResourceAmount = 0;
                Destroy(curPopUp);
                curPopUp = null;
                break;
            
            case (ResourceType.Corns):
                GameManager.Instance.SaveData.Corns += holdResourceAmount;
                holdResourceAmount = 0;
                Destroy(curPopUp);
                curPopUp = null;
                break;
            
            case (ResourceType.Potatoes):
                GameManager.Instance.SaveData.Potatoes += holdResourceAmount;
                holdResourceAmount = 0;
                Destroy(curPopUp);
                curPopUp = null;
                break;
            
            case (ResourceType.BioEthanol):
                GameManager.Instance.SaveData.Potatoes += holdResourceAmount;
                holdResourceAmount = 0;
                Destroy(curPopUp);
                curPopUp = null;
                break;
        }
    }
    
}
