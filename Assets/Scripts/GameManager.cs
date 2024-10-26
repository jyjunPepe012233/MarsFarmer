using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private JsonData _saveData;
    
    private bool _sleepTimeFlag = false;
    private bool _saveLoadFlag = false;

    [SerializeField] private ItemStatus itemStatus;
    [SerializeField] private BuildingStatus buildingStatus;
    public BuildingsID buildingsID;

    public List<ItemStatus.ItemStat> ItemStatus
    {
        get => itemStatus.itemStatus;
    }

    public List<BuildingStatus.BuildingStat> BuildingStatus {
        get => buildingStatus.buildingStats;
    }


    public int sleepTime;
    
    protected override void Init()
    {
        if (!File.Exists(Application.dataPath + "/SaveData.json"))
        {
            DataManager.Instance.GetEditJson(new JsonData());
        }
        
        _saveData = DataManager.Instance.LoadJson<JsonData>();
        try
        {
            UIUpdate();
            GetSleepTime();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    private void GetSleepTime()
    {
        for (int i = 0; i < _saveData.BuildingInfos.Count; i++)
        {
            DateTime lastGetTime =
                DateTime.ParseExact(_saveData.BuildingInfos[i].LastGetTime, "yyyy-MM-dd hh:mm:ss:tt", null);
            _saveData.BuildingInfos[i].SleepTime = (int)(lastGetTime - DateTime.Now).TotalSeconds;
        }
    }

    private void UIUpdate()
    {
        if (_saveData.UserName == "")
        {
            return;
        }
        
        UIManager.Instance.UserStatusUpdate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _saveData.Dollars = 999999;
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            DataManager.Instance.GetEditJson(_saveData);
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            DataManager.Instance.GetEditJson(_saveData);
        }
    }

    private void OnApplicationQuit()
    {
        DataManager.Instance.GetEditJson(_saveData);
    }
    
    public JsonData SaveData
    {
        get { return _saveData; }
        set { _saveData = value; }
    }
    
    
}
