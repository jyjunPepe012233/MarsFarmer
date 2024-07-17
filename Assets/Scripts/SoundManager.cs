using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public int thisFiled;
    
    [Header("#BGM")]
    public AudioClip[] bgmClips;
    public float bgmVolume;
    private AudioSource bgmPlayer;

    [Header("#Click")]
    public AudioClip[] clickClips;
    public float clickVolume;
    public int clickChannel;
    private AudioSource[] clickPlayers;
    private int clickChannelIndex;

    [Header("#Get")]
    public AudioClip[] getClips;
    public float getVolume;
    public int getChannel;
    private AudioSource[] getPlayers;
    private int getChannelIndex;
    
    private void Awake()
    {
        instance = this;
        Init();
    }

    void Init()
    {
        GameObject bgmObject = new GameObject("bgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent <AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClips[thisFiled];

        
        GameObject clickObject = new GameObject("clickPlayer"); 
        clickObject.transform.parent = transform;
        clickPlayers = new AudioSource[clickChannel];
        for (int i = 0; i < clickChannel; i++)
        {
            clickPlayers[i] = clickObject.AddComponent<AudioSource>();
            clickPlayers[i].volume = clickVolume;
            clickPlayers[i].playOnAwake = false;
            clickPlayers[i].loop = false;
        }

        GameObject getObject = new GameObject("getPlayer");
        getObject.transform.parent = transform;
        getPlayers = new AudioSource[getChannel];
        for (int i = 0; i < getChannel; i++)
        {
            getPlayers[i] = getObject.AddComponent<AudioSource>();
            getPlayers[i].loop = false;
            getPlayers[i].volume = getVolume;
            getPlayers[i].playOnAwake = false;
        }
    }

    public void clickSound(int index)
        /*
         - IndexList
         0 : 곡물창고 클릭 사운드
         1 : 공장 클릭 사운드
         2 : 농장클릭 사운드
         3 : 물 생상소 클릭 사운드
         4 : 물 저장소 클릭 사운드
         5 : 공사중 건물 클릭 사운드
         6 : 발전소 클릭 사운드
         7 : 산소 생성기 클릭 사운드
         8 : 산소 저장기 클릭 사운드
         9 : 베이스 클릭 사운드1
         11 : 전기 베터리 클릭 사운드
         12 : 건설완료 사운드
          */
    
    {
        clickChannelIndex = 0;
        for (int i = 0; i < clickChannel;i++)
        {
            if (!clickPlayers[i].isPlaying)
            {
                clickChannelIndex = i;
                break;
            } 
            clickPlayers[getChannelIndex].clip = getClips[i];
            clickPlayers[getChannelIndex].Play();
        }
    }
    public void getSound(int index)
        /*
         - IndexList
         0 : 곡물획득 사운드
         1 : 물 획득 사운
         2 : 물건 구매 사운드
         4 : 바이오 에탄올 획득 사운드
         5 : 산소 획득 사운드
         6 : 전기 획득 사운드
         7 ; 판매 사운드
          */
    
    {
        getChannelIndex = 0;
        for (int i = 0; i < getChannel;i++)
        {
            if (!getPlayers[i].isPlaying)
            {
                getChannelIndex = i;
                break;
            } 
            getPlayers[getChannelIndex].clip = getClips[i];
            getPlayers[getChannelIndex].Play();
        }
    }
    public void backSound(int index)
        /*
         - IndexList
         0 : 마트 BGM
         1 : 홈 화면 BGM
          */
    
    {
        
        bgmPlayer.clip = getClips[index];
        bgmPlayer.Play();
        
    }
}
