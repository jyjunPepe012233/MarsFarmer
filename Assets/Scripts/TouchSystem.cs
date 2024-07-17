using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSystem : MonoBehaviour {

	void Update() {
		
		if (Input.touchCount == 1) TouchRayCast();
	}

	void TouchRayCast() {

		Touch touch = Input.GetTouch(0);
		if (touch.phase == TouchPhase.Began) {

			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity)) {

				var obj = hitInfo.transform.gameObject;

				if (MapManager.Instance.isMapping) {
					MapManager.Instance.BuildingPlace(obj);
					return;
				}

				switch (obj.tag) {
					
					case ("Factory"):
						obj.GetComponent<Factory>().Select();
						break;
				}
			}
		}
	}
}
