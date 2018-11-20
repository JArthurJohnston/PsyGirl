using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVision : MonoBehaviour {

	public Vector3 TargetPosition {get; private set;}

	void Start(){
		TargetPosition = Vector3.zero;
	}

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag == "Player")
			TargetPosition = collider.transform.position;
	}

	void OnTriggerExit(Collider collider){
		if(collider.gameObject.tag == "Player")
			TargetPosition = Vector3.zero;
	}

	void OnTriggerStay(Collider collider){
		if(collider.gameObject.tag == "Player")
			TargetPosition = collider.transform.position;
	}
}
