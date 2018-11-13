using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour {
	static NavPoint[] navPoints;

	public static NavPoint getNewNavPoint(){
		int navPointIndex = Random.Range(0, navPoints.Length);
		return navPoints[navPointIndex];
	}

	void Start () {
		navPoints = GetComponentsInChildren<NavPoint>();
	}
}
