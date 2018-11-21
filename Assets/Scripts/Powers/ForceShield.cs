using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceShield : MonoBehaviour {

	public float radius;

	void Start(){
		transform.localScale = new Vector3(radius, radius, radius);
	}

	public void PowerDown(){
		Destroy(gameObject);
	}
}
