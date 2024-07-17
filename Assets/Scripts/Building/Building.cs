using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    [SerializeField] protected string _showName;
    [SerializeField] protected Vector2 _size;
    
    protected enum ResourceType {
        Oxygen,
        Water,
        Electricity,
        Rices,
        Corns,
        Potatoes
    }

    public string showName {
        get => _showName;
    }
    public Vector2 Size {
        get => _size;
    }
}
