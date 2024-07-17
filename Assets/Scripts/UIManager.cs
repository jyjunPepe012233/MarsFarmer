using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private string _userName;
    private int userLevel;
    
    protected override void Init()
    {
        
    }

    public void OnClickBuilding()
    {
        Debug.Log("Building Click");
    }

    public void OnClickMapping()
    {
        Debug.Log("Mapping Click");
    }

    public void OnClickProductList()
    {
        Debug.Log("Product List Click");
    }

    public void OnClickWorkerList()
    {
        Debug.Log("Worker List Click");    
    }

    public void OnClickMarket()
    {
        Debug.Log("Market Click");
    }

    public void OnClickWorkerGotcha()
    {
        Debug.Log("Worker Gotcha Click");
    }

    public void OnClickPost()
    {
        Debug.Log("Post Click");
    }

    public void OnClickQuest()
    {
        Debug.Log("Quest Click");
    }

    public void OnClickSetting()
    {
        Debug.Log("Setting Click");
    }
    
}
