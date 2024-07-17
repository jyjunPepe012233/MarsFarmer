using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private GameObject _homeUI;

    [SerializeField]
    private GameObject _mappingUI;
    
    [SerializeField]
    private TextMeshProUGUI _userNameText;
    [SerializeField]
    private TextMeshProUGUI _userLevelText;
    [SerializeField]
    private TextMeshProUGUI _dollarsText;
    [SerializeField]
    private TextMeshProUGUI _rubysText;
    
    protected override void Init()
    {
        
    }

    public void UIInit()
    {
        _homeUI.SetActive(true);
        _mappingUI.SetActive(false);
        
    }
    
    public void UserStatusUpdate()
    {
        _userNameText.text = GameManager.Instance.SaveData.UserName;
        _userLevelText.text = GameManager.Instance.SaveData.UserLevel.ToString();
        _dollarsText.text = GameManager.Instance.SaveData.Dollars.ToString() + " $";
        _rubysText.text = GameManager.Instance.SaveData.Rubys.ToString();
    }

    public void OnClickBuilding()
    {
        Debug.Log("Building Click");
    }

    public void OnClickMapping()
    {
        Debug.Log("Mapping Click");
        _homeUI.SetActive(false);
        _mappingUI.SetActive(true);
        
        MapManager.Instance.EnterMapping();
    }

    public void ExitMapping()
    {
        Debug.Log("Mapping Exit");
        _homeUI.SetActive(true);
        _mappingUI.SetActive(false);
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
