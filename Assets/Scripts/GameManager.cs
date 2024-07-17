using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

	[SerializeField] private ItemStatus itemStatus;
	[SerializeField] private BuildingStatus buildingStatus;

	public List<ItemStatus.ItemStat> ItemStatus {
		get => itemStatus.itemStatus;
	}
	public List<BuildingStatus.BuildingStat> BuildingStatus {
		get => buildingStatus.buildingStats;
	}
}


public enum ResourceType {
	Oxygen,
	Water,
	Electricity,
	Rices,
	Corns,
	Potatoes,
	BioEthanol
}