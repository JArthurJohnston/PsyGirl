using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public float BulletsPerSecond;

	public TurretVision Vision;
	Gun TurretGun;

	void Start(){
		TurretGun = GetComponent<Gun>();
		InvokeRepeating("ShootTarget", 0.0f, 1.0f / BulletsPerSecond);
	}

	void ShootTarget(){
		if(Vision.TargetPosition != Vector3.zero){
			FireAt(Vision.TargetPosition);
		}
	}

	public void FireAt(Vector3 target){
		transform.LookAt(target);
		TurretGun.Fire();
	}

}
