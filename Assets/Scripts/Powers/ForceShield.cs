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

	// void OnCollisionEnter(Collision collider){
	// 	Debug.Log("Collided With: " + collider.gameObject.name);
	// }

	// void OnTriggerEnter(Collider collider){
	// 	Debug.Log("Entered By: " + collider.gameObject.name);
	// }

	// void OnTriggerStay(Collider collider){
	// 	Debug.Log("Stay By: " + collider.gameObject.name);
	// }

	void Update(){
		transform.position = ShieldPosition();
	}

	public GameObject RaiseNewShields(){
		var playerTransform = Player.Main.transform;
		return Instantiate(gameObject, ShieldPosition(), playerTransform.rotation);
	}

	private Vector3 ShieldPosition(){
		return Player.Main.transform.position + Player.Main.transform.up * upOffset;
	}
}
