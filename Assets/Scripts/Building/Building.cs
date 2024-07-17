using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour {

    [SerializeField] protected int _buildingIndex;
    
    [Space(5f)]
    [SerializeField] protected Vector2 _size;
    
    [Space(5f)]
    [SerializeField] protected int buildPrice;
    [SerializeField] protected int buildMinute;

    [SerializeField] protected bool isCantPlace;
    

    
    protected BuildingStatus.BuildingStat status;
    public BuildingStatus.BuildingStat Status {
        get => status;
    }

    public Vector2 Size {
        get => _size;
    }


    
    void FixedUpdate() {
        if (!MapManager.Instance.isCantPlace) MapManager.Instance.isCantPlace = isCantPlace;
        isCantPlace = false;
    }

    public abstract void SetupBuilding();

    public abstract void Select();

    
    
    private void OnTriggerStay(Collider other) {
        isCantPlace = true;
    }
}
