using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public float damage;

	public GameObject originPoint;

	public Bullet bulletTemplate;

	public void Fire(){
		var bullet = Instantiate(bulletTemplate, originPoint.transform.position, transform.rotation);
		bullet.Damage = damage;
	}

}
