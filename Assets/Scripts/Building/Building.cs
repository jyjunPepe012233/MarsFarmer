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

    
    protected BuildingStatus.BuildingStat status;
    public BuildingStatus.BuildingStat Status {
        get => status;
    }

    public Vector2 Size {
        get => _size;
    }

    public abstract void SetupBuilding();
}
