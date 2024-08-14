using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Building), true)]
public class BuildingEditor : Editor {

	private Building tg;

	private bool isClickCopy;
	private bool isClickOverride;

	void OnEnable() {

		tg = target as Building;
	}


	public override void OnInspectorGUI() {

		base.OnInspectorGUI();

		EditorGUILayout.Space(10f);
		if (GUILayout.Button("Setup Building")) {
			tg.SetupBuilding();
		}
	}
}
