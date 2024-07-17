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

    private BoxCollider collider;
    [SerializeField] private bool isCantPlace;
    

    
    protected BuildingStatus.BuildingStat status;
    public BuildingStatus.BuildingStat Status {
        get => status;
    }

    public Vector2 Size {
        get => _size;
    }

    void Awake() {

        collider = GetComponent<BoxCollider>();
    }

    void Update() {

        isCantPlace = MapManager.Instance.isCantPlace;
        Debug.Log(1);
    }

    public abstract void SetupBuilding();

    public abstract void Select();

    
    protected void OnTriggerEnter(Collider other) {
        isCantPlace = false;
    }

    protected void OnTriggerExit(Collider other) {
        isCantPlace = true;
    }
}
