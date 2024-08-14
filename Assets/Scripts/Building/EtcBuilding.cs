using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EtcBuilding : Building {


    public override void SetupBuilding() {

        status = GameManager.Instance.BuildingStatus[_buildingIndex];


        gameObject.name = status.name;
        _size = status.size;
        buildPrice = status.buildPrice;
        buildMinute = status.buildMinute;
    }


    public override void Select() {
    }

}
