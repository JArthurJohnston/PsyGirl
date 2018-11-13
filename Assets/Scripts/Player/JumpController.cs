using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour {

	public float jumpSpeed;
	private float startingY;

	void Start(){
		startingY = transform.position.y + 0.25f;
	}
	
	void Update () {
		if(Input.GetAxis("Jump") > 0){
			if(transform.position.y <= startingY){
				var rotation = transform.rotation;
				GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
				transform.rotation = rotation;
			}
		}
	}
}
