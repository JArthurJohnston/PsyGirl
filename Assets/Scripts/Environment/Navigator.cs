using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour {
	static GameObject[] navPoints;

	public static GameObject getNewNavPoint(){
		int navPointIndex = Random.Range(0, navPoints.Length);
		return navPoints[navPointIndex];
	}

	void Start () {
		navPoints = GameObject.FindGameObjectsWithTag("Nav");
	}
}
