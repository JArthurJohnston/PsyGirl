using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public float damage;

	public GameObject originPoint; //replace this with transform.forward + someDistance

	public Bullet bulletTemplate;

	public void Fire(){
		bulletTemplate.FireFrom(originPoint.transform, damage);
	}

}
