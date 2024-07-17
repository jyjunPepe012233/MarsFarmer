using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private JsonData _saveData;
    private bool _sleepTimeFlag = false;
    private bool _saveLoadFlag = false;

    private ItemStatus itemStatus;
    private BuildingStatus buildingStatus;
    public BuildingsID buildingsID;

    public List<ItemStatus.ItemStat> ItemStatus {
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
        GetSleepTime();
    }

    private void GetSleepTime()
    {
        if (_saveData.BuildingInfos == null)
        {
            return;
        }
        
        for (int i = 0; i < _saveData.BuildingInfos.Count; i++)
        {
            DateTime lastGetTime =
                DateTime.ParseExact(_saveData.BuildingInfos[i].LastGetTime, "yyyy-MM-dd hh:mm:ss:tt", null);
            _saveData.BuildingInfos[i].SleepTime = (int)(lastGetTime - DateTime.Now).TotalSeconds;
        }
        
    }

    
    public JsonData SaveData
    {
        get { return _saveData; }
        set { _saveData = value; }
    }
    
    
}
