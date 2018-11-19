using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public Bullet bulletTemplate;

	public void Fire(){
		Instantiate(bulletTemplate, transform.position, transform.rotation);
	}

}
