using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip homeBGM;
    public AudioClip marketBGM;
    [Header("get")]
    public AudioClip getWater;
    public AudioClip getGrain;
    public AudioClip getVoltage;
    public AudioClip getAir;
    public AudioClip getEthanol;
    [Header("click")]
    public AudioClip clickWaterStorage;
    public AudioClip clickGrainStorage;
    public AudioClip clickVoltageStorage;
    public AudioClip clickAirStorage;
    public AudioClip clickEthanolStorage;
    public AudioClip clickMarket;
    public AudioClip clickBase1;
    public AudioClip clickBase2;
    public AudioClip clickWaterProduction;
    public AudioClip clickGrainProduction;
    public AudioClip clickVoltageProduction;
    public AudioClip clickAirProduction;
    public AudioClip clickEthanolProduction;
    [Header("gita")]
    public AudioClip buy;
    public AudioClip sell;
    public AudioClip marketIn;
    public AudioClip marketOut;
    public AudioClip constructionStart;
    public AudioClip clickConstruction;
    public AudioClip constructionEnd;


    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
