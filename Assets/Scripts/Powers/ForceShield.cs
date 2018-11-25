using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceShield : MonoBehaviour {

	public float radius;

	public float upOffset;

	ForceShield shield;

	void Start(){
		transform.localScale = new Vector3(radius, radius, radius);
	}

	public void PowerUp(){
		// gameObject.SetActive(true);
		var playerTransform = Player.Main.transform;
		var shieldPosition = playerTransform.position + playerTransform.up * upOffset;
		Instantiate(this, shieldPosition, playerTransform.rotation);
	}

	public void PowerDown(){
		Destroy(gameObject, 0);
		// DestroyImmediate(gameObject, true);
		// gameObject.SetActive(false);
	}
}
