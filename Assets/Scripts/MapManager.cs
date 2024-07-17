using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public struct Vector222 {
    public Vector3 minPos;
    public Vector3 maxPos;

    public Vector222(Vector3 minPos, Vector3 maxPos) {
        this.minPos = minPos;
        this.maxPos = maxPos;
    }
}


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

    public bool isCantPlace;

    public GameObject PlacingObject {
        get => placingObject;
        set => placingObject = value;
    }

    public List<Vector222> usedGrid = new List<Vector222>();
    
    

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

        isCantPlace = false;
        usedGrid.Clear();
    }


    void Mapping() {

        if (placingObject == null) return;
        
        placingSign.SetActive(true);

        
        if (oldBuildingPos == null) oldBuildingPos = placingObject.transform.position;

        placingSign.GetComponent<RectTransform>().position =
            CameraManager.Instance.camData.WorldToScreenPoint(placingObject.transform.position);

        
        
        Debug.Log(isCantPlace);
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
        }
        
        oldBuildingPos = null;
        placingObject = null;
        
        placingSign.SetActive(false);
    }
}
