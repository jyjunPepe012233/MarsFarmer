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

    // void getWaterSound(int index)
    // {
    //     getChannelIndex = 0;
    //     for (int i = 0; i < getChannelIndex;i++)
    //     {
    //         if()
    //     }
    // }
}
