using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public Canvas _canvas;
    
    [SerializeField]
    private GameObject _homeUI;

    [SerializeField]
    private GameObject _mappingUI;

    [SerializeField]
    private GameObject _marketUI;

    [SerializeField]
    private GameObject _marketFirstUI;

    [SerializeField]
    private GameObject _marketBuyUI;

    [SerializeField]
    private GameObject _realBuyPopUp;
    
    [SerializeField]
    private TextMeshProUGUI _userNameText;
    [SerializeField]
    private TextMeshProUGUI _userLevelText;
    [SerializeField]
    private TextMeshProUGUI _dollarsText;
    [SerializeField]
    private TextMeshProUGUI _rubysText;

    private int _buildingIndex;
    
    protected override void Init()
    {
        
    }

    public void UIInit()
    {
        _homeUI.SetActive(true);
        _mappingUI.SetActive(false);
        _marketUI.SetActive(false);
        _marketFirstUI.SetActive(false);
        _marketBuyUI.SetActive(false);
        _realBuyPopUp.SetActive(false);
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
        _homeUI.SetActive(false);
        _marketUI.SetActive(true);
        _marketFirstUI.SetActive(true);
    }

    public void ExitMarket()
    {
        Debug.Log("Exit Market Click");
        _homeUI.SetActive(true);
        _marketUI.SetActive(false);
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

    public void OnClickBuyJoin()
    {
        Debug.Log("Buy Join Click");
        _marketFirstUI.SetActive(false);
        _marketBuyUI.SetActive(true);
    }

    public void ExitMarketJoin()
    {
        Debug.Log("Exit Click");
        _marketFirstUI.SetActive(true);
        _marketBuyUI.SetActive(false);
    }

    public void OnClickSellJoin()
    {
        Debug.Log("Sell Join Click");
    }

    public void OnClickGotcha()
    {
        Debug.Log("Gotcha Join Click");
    }

    public void OverDollar()
    {
        Debug.Log("Dollar Over");
    }

    public void OnBuyRice()
    {
        _realBuyPopUp.SetActive(true);
    }
    
    public void OnBuyCorn()
    {
        _realBuyPopUp.SetActive(true);
    }
    
    public void OnBuyPotato()
    {
        _realBuyPopUp.SetActive(true);
    }

    public void OnBuyCancel()
    {
        _realBuyPopUp.SetActive(false);
    }

    public void OnBuy()
    {
        _realBuyPopUp.SetActive(false);
    }

    public void OnBuyBuilding(int buildingIndex)
    {
        _buildingIndex = buildingIndex;
        _realBuyPopUp.SetActive(true);
    }

}
