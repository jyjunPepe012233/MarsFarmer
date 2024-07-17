using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapManager : Singleton<MapManager> {

    private List<BuildingInfo> _buildingInfos; // 세이브에서 Load 필요
    private List<Building> _buildings;

    [Space(10)]
    [SerializeField] private BuildingsID buildingsIdData;

    public bool isMapping;
    [SerializeField] private GameObject placingObject;
    [SerializeField] private GameObject placingSign;

    public GameObject PlacingObject {
        set => placingObject = value;
    }
    
    
    
    void LoadBuildings() {  

        foreach (Building building in _buildings) {
            Destroy(building.gameObject);
        }

        // 세이브에서 Load

        foreach (BuildingInfo info in _buildingInfos) {
            
            var data = buildingsIdData.GetPrefab(info.Building) .GetComponent<Building>(); ;

            var buildingPos = new Vector3(data.Size.x / 2, 0, data.Size.y / 2);
            buildingPos += new Vector3(info.Pos[0] - 0.5f, 0, info.Pos[1] - 0.5f);
            _buildings.Add( Instantiate(data.gameObject, buildingPos, Quaternion.identity).GetComponent<Building>() );
        }
    }

    public void EnterMapping() {

        isMapping = true;

    }

    void EndMapping() {

        UIManager.Instance.ExitMapping();
        
        isMapping = false;
    }
    
    
    
    void Update() {

        if (isMapping && Input.GetKeyDown(KeyCode.Escape)) { // 뒤로가기
            EndMapping();
        }
        
        if (isMapping) Mapping();
    }


    void Mapping() {

        if (placingObject == null) return;

        var sign = Instantiate(placingSign);
        sign.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(placingObject.transform.position);
    }

    public void ChoiceYes() {
        
        EndChoice();
    }

    public void EndChoice() {

        placingObject = null;
        Destroy(placingSign);
    }
}
