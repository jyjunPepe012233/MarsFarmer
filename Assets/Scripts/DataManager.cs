using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private string SavePath()
    {
        return Application.dataPath + "/SaveData.json";
    }

    private void EditJson(JsonData jsonData)
    {
        string saveData = JsonUtility.ToJson(jsonData, true);
        File.WriteAllText(SavePath(), saveData, Encoding.UTF8);
    }

    public JsonData LoadJson<JsonData>()
    {
        string jsonData = File.ReadAllText(SavePath(), Encoding.UTF8);
        return JsonUtility.FromJson<JsonData>(jsonData);
    }

    public void GetEditJson(JsonData jsonData)
    {
        EditJson(jsonData);
    }
}
