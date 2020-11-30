using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Originated from https://ansimuz.itch.io/ and his Quiet Hill parallax code
/// Refitted to work for moving across a level
/// </summary>

public class LevelMotor : MonoBehaviour {

	[Header("Background & Parallax")]
	public GameObject[] backgrounds;
	public float smoothing = 5;
	
	private float[] _parallaxScales;
	private Vector3 _previousCameraPosition;

	[Header("Movement Settings")]
	[SerializeField] private float moveSpeed;
	[SerializeField] private Vector2 boundaries;

	private bool _isMoving;
	private Vector3 _vel = Vector3.zero;
	
	void Start () {
 		
		_previousCameraPosition = transform.position;				// Get last known position (starting point)
		backgrounds = GameObject.FindGameObjectsWithTag("BG_P");	// Get all background images
		_parallaxScales = new float[backgrounds.Length];			// Get background offset
		for(int i = 0; i < _parallaxScales.Length; i++){			// Not really sure tbh
			_parallaxScales [i] = backgrounds [i].transform.position.z * -1;
		}
	}

	public void Move(int dir)
	{
		if (dir < 0 && moveSpeed > 0)
			moveSpeed *= dir;
		else if(dir > 0 && moveSpeed < 0) moveSpeed *= -dir;
		_isMoving = true;
	}

	public void Stop()
	{
		_isMoving = false;
	}

	private void FixedUpdate()
	{
		if (_isMoving)
		{
			var targetPos = transform.position;
			var pos = targetPos;
			pos.x -= moveSpeed * Time.deltaTime;
			
			// Check boundaries
			if (pos.x < boundaries.x)
				pos.x = boundaries.x;
			else if (pos.x > boundaries.y)
				pos.x = boundaries.y;
			
			targetPos = Vector3.SmoothDamp(targetPos,pos,ref _vel, Time.deltaTime);
			transform.position = targetPos;
		}
	}
	
	void LateUpdate () {
		for(int i = 0; i < backgrounds.Length; i++){
			Vector3 parallax = (_previousCameraPosition - transform.position) * (_parallaxScales [i] / smoothing);
			var pos = backgrounds[i].transform.position;
			backgrounds [i].transform.position = new Vector3 (pos.x + parallax.x, pos.y + parallax.y, pos.z);
		}	

		_previousCameraPosition = transform.position;
	}

	 
}
