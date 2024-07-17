using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    protected override void Init()
    {
        
    }

    public void OnClickBuilding()
    {
        Debug.Log("Building Click");
    }
}
