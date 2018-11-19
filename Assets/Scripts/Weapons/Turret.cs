using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public TurretVision Vision;
	Gun TurretGun;

	void Start(){
		TurretGun = GetComponent<Gun>();
	}

	void Update(){
		if(Vision.TargetPosition != Vector3.zero){
			FireAt(Vision.TargetPosition);
		}
	}

	public void FireAt(Vector3 target){
		transform.LookAt(target);
		TurretGun.Fire();
	}

}
