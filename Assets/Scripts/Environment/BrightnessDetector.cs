using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessDetector : MonoBehaviour {

	private GameObject[] lights;

	// Use this for initialization
	void Start () {
		lights = GameObject.FindGameObjectsWithTag("Light Source");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach (var eachLight in lights)
		{
			var distanceToPlayer = Vector3.Distance(eachLight.transform.position, Player.Main.transform.position);
		}
	}
}
