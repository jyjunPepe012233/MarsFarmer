using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mars Farmer/Building Status", fileName = "Building Status", order = int.MinValue)]
public class BuildingStatus : ScriptableObject {

	[System.Serializable]
	public struct BuildingStat {
		public string name;
		
		[Space(5)]
		public Vector2 size;
		public int buildPrice;
		public int buildMinute;

		[Space(5)] 
		public List<ResourceType> itemTypes;
	}
	public List<BuildingStat> buildingStats;
	
}
