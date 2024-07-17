using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mars Farmer/Buildings ID", fileName = "Buildings ID", order = int.MaxValue)]
public class BuildingsID : ScriptableObject {

	[System.Serializable]
	public struct BuildingWithID {
		public string id;
		public GameObject buildingPrefab;
	}
	public List<BuildingWithID> buildingWithId;

	public GameObject GetPrefab(string id) {

		foreach (BuildingWithID info in buildingWithId) {
			if (info.id == id) return info.buildingPrefab;
		}

		return null;
	}

}
