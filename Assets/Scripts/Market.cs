using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Market : Singleton<Market>
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
            type = T; // 자원 :1, 건물 :2, 종자 :3
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

    protected override void Init()
    {
        Buildings = new Product[BuildingKind];
        seeds = new Product[seedKind];
    }

    public void BuyBuilding(int buyBuilding)
    {
        if (GameManager.Instance.SaveData.Dollars < GrainSellPrice[buyBuilding])
        {
            UIManager.Instance.OverDollar();
        }
        else
        {
            GameManager.Instance.SaveData.Dollars =
                GameManager.Instance.SaveData.Dollars - GrainSellPrice[buyBuilding];
            SoundManager.instance.getSound(2);
        }
    }
    
    public void BuySeed(int buySeed)
    {
        if (GameManager.Instance.SaveData.Dollars < GrainSellPrice[buySeed])
        {
            UIManager.Instance.OverDollar();
        }
        else
        {
            GameManager.Instance.SaveData.Dollars =
                GameManager.Instance.SaveData.Dollars - GrainSellPrice[buySeed];
            SoundManager.instance.getSound(0);
        }
    }

    public void sellGrain(int sellGrain, int grainQuntity)
    {
        GameManager.Instance.SaveData.Dollars += GrainSellPrice[sellGrain] * grainQuntity;
        SoundManager.instance.getSound(7);
    }

    public (string,Sprite,int)[] getBuildings()
    {
        var returnList = new (string, Sprite, int)[BuildingKind];
        for (int i=0; i < Buildings.Length;i++)
        {
            (string, Sprite, int) returnTuple = (Buildings[i].getName(), Buildings[i].getImage(), Buildings[i].getBuyPrice());
            returnList[i] = returnTuple;
        }

        return returnList;
    }

    public (string, Sprite, int)[] getSeeds()
    {
        var returnList = new (string, Sprite, int)[seedKind];
        for (int i=0; i < seeds.Length;i++)
        {
            (string, Sprite, int) returnTuple = (seeds[i].getName(), seeds[i].getImage(), seeds[i].getBuyPrice());
            returnList[i] = returnTuple;
        }

        return returnList;
    }
    
    
    //================================================================== 갓☆챠
    
    private class Slave
    {
        private string name;
        private int tier;
        private Sprite slaveImage;
        private float skills;
        private int gender;
        private int color;
        private string Description;

        public Slave(string N, int T)
        {
            name = N;
            tier = T;
        }
        
        public Slave(string N,int T, float S, int G, int C, string D)
        {
            name = N;
            tier = T;
            skills = S;
            gender = G;
            color = C;
            Description = D;
        }

        private new Slave[] CTierSlaves = 
            new Slave[]
            {
                new Slave("뽀삐",1),
                new Slave("민준", 1),
                new Slave("서연", 1),
                new Slave("지훈", 1),
                new Slave("지우", 1),
                new Slave("하준", 1),
                new Slave("은채", 1),
                new Slave("유진", 1),
                new Slave("호준", 1),
                new Slave("나연", 1),
                new Slave("수빈", 1)
            };
        private new Slave[] BTierSlaves = 
            new Slave[]
            {
                new Slave("하진", 2),
                new Slave("지수", 2),
                new Slave("진우", 2),
                new Slave("소연", 2),
                new Slave("현정", 2),
                new Slave("태현", 2),
                new Slave("민서", 2),
                new Slave("우진", 2),
                new Slave("아영", 2),
                new Slave("준호", 2)
            };
        private new Slave[] ATierSlaves = 
            new Slave[]
            {
                new Slave("유리", 3),
                new Slave("정우", 3),
                new Slave("하늘", 3),
                new Slave("세영", 3),
                new Slave("지훈", 3),
                new Slave("민규", 3),
                new Slave("수연", 3),
                new Slave("건우", 3),
                new Slave("지안", 3),
                new Slave("효진", 3)
            };
        private new Slave[] STierSlaves = 
            new Slave[]
            {
                new Slave("춘자", 4),
                new Slave("춘식", 4),
                new Slave("영희", 4),
                new Slave("광자", 4),
                new Slave("루피", 4),
                new Slave("철수", 4)
            };
        
        
    public int SlavePick(Slave[] slaves)
    {
        return randint(0,slaves.Length);
    }
        
    public int randint(int min, int max)
    {
        return Random.Range(min,max);
    }

    public Slave gadCha()
    {
        var cha = randint(1, 1000);
        if (cha >= 600) //C등급
        {
            return CTierSlaves[SlavePick(CTierSlaves)];
        }
        else if (cha >= 900) //B등급
        {
            return BTierSlaves[SlavePick(BTierSlaves)];
        }
        else if (cha >= 1000) //A등급
        {
            return ATierSlaves[SlavePick(ATierSlaves)];
        }
        else //S 등급
        {
            return STierSlaves[SlavePick(STierSlaves)];
        }
        
        }

    }
    
    
}