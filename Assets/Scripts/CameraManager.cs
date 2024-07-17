using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager> {

	public Transform _cam;
	[SerializeField] private Transform _camArm;
	[SerializeField, Range(0, 90)] private float _camAngle;
	
	[Space(10), Tooltip("min speed, max speed")]
	[SerializeField] private Vector2 _camMoveSpeed;
	[Space(5)]
	[SerializeField] private Vector3 _minPosition;
	[SerializeField] private Vector3 _maxPosition;

	[Space(10)]
	[SerializeField] private float _zoomSpeed;
	[SerializeField] private Vector2 _distanceClamp;

	[Space(5)]
	[SerializeField, Range(0, 1)] private float _distanceIndex;

	public Camera camData;
	
	


	private float _camDistance;
	private Quaternion _camMoveDirx;
	


	void Awake() {

		_camArm.position = Vector3.zero;
		
		_camMoveDirx = Quaternion.Euler(0, 45, 0);
		_camArm.rotation = Quaternion.Euler(new Vector3(_camAngle, 45, 0));
		
		_cam.rotation = _camArm.rotation;

	}
	

	void Update() {

		if (MapManager.Instance.PlacingObject != null) return;
		
		if (Input.touchCount == 1) Move();
		if (Input.touchCount == 2) ZoomInOut();
		
		_camDistance = Mathf.Lerp(_distanceClamp.x, _distanceClamp.y, _distanceIndex);
		_cam.position = _camArm.TransformPoint(new Vector3(0, 0, -_camDistance));
		
	}


	void Move() {

		Vector2 touchInput = Input.GetTouch(0).deltaPosition;

		var addPos = -(_camMoveDirx * new Vector3(touchInput.x, 0, touchInput.y)); 
		var newPos = _camArm.position + addPos * Mathf.Lerp(_camMoveSpeed.x, _camMoveSpeed.y, _distanceIndex);

		newPos.x = Mathf.Clamp(newPos.x, _minPosition.x, _maxPosition.x);
		newPos.z = Mathf.Clamp(newPos.z, _minPosition.z, _maxPosition.z);

		_camArm.position = newPos;
	}




	void ZoomInOut() {

		Touch touch1 = Input.GetTouch(0);
		Touch touch2 = Input.GetTouch(1);

		var oldDistance = Vector2.Distance(touch1.position - touch1.deltaPosition, touch2.position - touch2.deltaPosition);
		var curDistance = Vector2.Distance(touch1.position, touch2.position);

		_distanceIndex += (oldDistance - curDistance) * _zoomSpeed;
	}


	private void OnDrawGizmosSelected() {

		Gizmos.color = Color.white;
		Gizmos.DrawSphere(_cam.position, 0.1f);
		Gizmos.DrawSphere(_camArm.position, 0.1f);
		Gizmos.DrawLine(_cam.position, _camArm.position);
	} 
}
