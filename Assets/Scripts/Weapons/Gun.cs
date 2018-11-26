using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public float damage;

	public GameObject originPoint; //replace this with transform.forward + someDistance

	public void Fire(){
		Bullet.FireFrom(originPoint.transform, damage);
	}

}
