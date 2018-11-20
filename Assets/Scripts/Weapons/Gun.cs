﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public float damage;

	public Bullet bulletTemplate;

	public void Fire(){
		var bullet = Instantiate(bulletTemplate, transform.position, transform.rotation);
		bullet.Damage = damage;
	}

}
