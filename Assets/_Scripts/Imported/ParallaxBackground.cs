using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

	public GameObject[] backgrounds;
	private float[] parallaxScales;
	public float smoothing;

	private Vector3 previousCameraPosition;

	[Header("Movement Settings")]
	public float moveSpeed;
	public bool testmoving{ get; set; }

	

	private Vector3 _vel = new Vector3();
	// Use this for initialization
	void Start () {
 		
		previousCameraPosition = transform.position;
		backgrounds = GameObject.FindGameObjectsWithTag("BG_P");
		parallaxScales = new float[backgrounds.Length];
		for(int i = 0; i < parallaxScales.Length; i++){
			parallaxScales [i] = backgrounds [i].transform.position.z * -1;
		}

	}

	private void FixedUpdate()
	{
		if (testmoving)
		{
			var pos = transform.position;
			pos.x -= moveSpeed * Time.deltaTime;
			transform.position = Vector3.SmoothDamp(transform.position,pos,ref _vel, Time.deltaTime);
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		for(int i = 0; i < backgrounds.Length; i++){
			Vector3 parallax = (previousCameraPosition - transform.position) * (parallaxScales [i] / smoothing);
			backgrounds [i].transform.position = new Vector3 (backgrounds[i].transform.position.x + parallax.x, backgrounds[i].transform.position.y + parallax.y, backgrounds[i].transform.position.z);
		}	

		previousCameraPosition = transform.position;
	}

	 
}
