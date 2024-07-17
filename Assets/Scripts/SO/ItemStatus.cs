using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Mars Farmer/Item Status", fileName = "Item Status", order = int.MinValue)]
public class ItemStatus : ScriptableObject {

	[System.Serializable]
	public struct ItemStat {
		public ResourceType type;
		[Space(5)]
		public float collectAmountHour;
		public int sellPrice;
	}
	public List<ItemStat> itemStatus;
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
