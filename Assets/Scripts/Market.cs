using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
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
    
    //GameManager.Instance.SaveData.dollors

    int BuyBuilding(int buyBuilding,int BuildingQuntity)
    {
        if (GameManager.Instance.SaveData.Dollars > GrainSellPrice[buyBuilding]*BuildingQuntity)
        {
            return 0;
        }
        else
        {
            return BuildingBuyPrice[buyBuilding] * BuildingQuntity - GameManager.Instance.SaveData.Dollars;
        }
    }

    int sellGrain(int sellGrain, int grainQuntity)
    {
        return GameManager.Instance.SaveData.Dollars + GrainSellPrice[sellGrain] * grainQuntity;
    }

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