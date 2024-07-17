using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Building {

    [Serializable]
    private struct StoreInfo {
        public ResourceType resourceType;
        public float storeAmount;
    }
    [Space(10f), SerializeField] private List<StoreInfo> storeInfos;

}
