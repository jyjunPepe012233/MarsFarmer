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

    public Vector3? oldBuildingPos;
    public Vector3? newBuildingPos;

    public GameObject PlacingObject {
        get => placingObject;
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

    public void EndMapping() {

        UIManager.Instance.ExitMapping();
        
        EndChoice();
        isMapping = false;
    }


    public void Awake() {
        placingSign.SetActive(false);
    }
    
    
    void LateUpdate() {

        if (isMapping && Input.GetKeyDown(KeyCode.Escape)) { // 뒤로가기
            EndMapping();
        }
        
        if (isMapping) Mapping();
    }


    void Mapping() {

        if (placingObject == null) return;
        
        if (oldBuildingPos == null) oldBuildingPos = placingObject.transform.position;
        
        placingSign.SetActive(true);

        placingSign.GetComponent<RectTransform>().position =
            CameraManager.Instance.camData.WorldToScreenPoint(placingObject.transform.position);

        
        
        if (Input.touchCount == 1) {
            
            Touch touch = Input.GetTouch(0);

            if (touch.phase != TouchPhase.Moved) return;
            
            Ray ray = CameraManager.Instance.camData.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out RaycastHit hitinfo, Mathf.Infinity, LayerMask.GetMask("Ground"))) {
                
                newBuildingPos = new Vector3((int)hitinfo.point.x, 0, (int)hitinfo.point.z);
                
                placingObject.transform.position = (Vector3)newBuildingPos;
            }


        }

    }

    public void ChoiceYes() {

        newBuildingPos = null;
        oldBuildingPos = null;

        placingObject = null;
        placingSign.SetActive(false);


    }

    public void EndChoice() {

        newBuildingPos = null;
        if (oldBuildingPos != null) {
            placingObject.transform.position = (Vector3)oldBuildingPos;
        } else placingObject.transform.position = Vector3.zero;
        oldBuildingPos = null;
        placingObject = null;
        
        placingSign.SetActive(false);
    }
}
