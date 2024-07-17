using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Market : MonoBehaviour
{
    
    /*
     0 : 쌀 -
     1 : 옥수슈
     2 : 감자
     3 : 에탄올
     */
    
    private List<int> GrainSellPrice = new List<int>(){1,2,3,4};
    private List<int> BuildingBuyPrice = new List<int>(){1,2,3,4,5,6,7,8,9,10};
    private Product[] Buildings;
    private Product[] seeds;

    [SerializeField] private int seedKind;
    [SerializeField] private int BuildingKind;
    [SerializeField] private int GrainKind;

    private class Product
    {
        [SerializeField]private string name;
        [SerializeField]private Sprite itemImage;
        [SerializeField]private int type;
        [SerializeField]private int itemNumber;
        [SerializeField]private int buyPrice;
        [SerializeField]private int sellPrice;

        public Product(string N,Sprite I,int T, int INo, int BPr, int Spr)
        {
            name = N;
            itemImage = I;
            type = T; // 자원 :1, 건뭉 :2, 종자 :3
            itemNumber = INo;
            buyPrice = BPr;
            sellPrice = Spr;
        }

        public string getName() 
        { return name; }
        public int getBuyPrice() 
        { return buyPrice; }
        public int getsellPrice()
        { return sellPrice; }
        public Sprite getImage()
        { return itemImage; }
        public int getType()
        { return type; }
        public int getItemNumber()
        { return itemNumber; }

    }
    
    //GameManager.Instance.SaveData.dollors

    private void Awake()
    {
        Buildings = new Product[BuildingKind];
        seeds = new Product[seedKind];
    }

    void BuyBuilding(int buyBuilding,int BuildingQuntity)
    {
        if (GameManager.Instance.SaveData.Dollars < GrainSellPrice[buyBuilding]*BuildingQuntity)
        {
            UIManager.Instance.OverDollar();
        }
        else
        {
            GameManager.Instance.SaveData.Dollars =
                GameManager.Instance.SaveData.Dollars - GrainSellPrice[buyBuilding] * BuildingQuntity;
            SoundManager.instance.getSound(2);
        }
    }

    void sellGrain(int sellGrain, int grainQuntity)
    {
        
        GameManager.Instance.SaveData.Dollars += GrainSellPrice[sellGrain] * grainQuntity;
        SoundManager.instance.getSound(7);
    }

    (string,Sprite,int)[] getBuildings()
    {
        var returnList = new (string, Sprite, int)[BuildingKind];
        for (int i=0; i < Buildings.Length;i++)
        {
            (string, Sprite, int) returnTuple = (Buildings[i].getName(), Buildings[i].getImage(), Buildings[i].getBuyPrice());
            returnList[i] = returnTuple;
        }

        return returnList;
    }

    (string, Sprite, int)[] getSeeds()
    {
        var returnList = new (string, Sprite, int)[seedKind];
        for (int i=0; i < seeds.Length;i++)
        {
            (string, Sprite, int) returnTuple = (seeds[i].getName(), seeds[i].getImage(), seeds[i].getBuyPrice());
            returnList[i] = returnTuple;
        }

        return returnList;
    }
    
    
    //==================================================================
    
    private class Slave
    {
        private string name;
        private int tier;
        private float skills;
        private int gender;
        private int color;
        private string Description;

        public Slave(string N,int T, float S, int G, int C, string D)
        {
            name = N;
            tier = T;
            skills = S;
            gender = G;
            color = C;
            Description = D;
        }

        // Vector4 getStatus()
        // {
        //     
        // }
    }
    
    
}