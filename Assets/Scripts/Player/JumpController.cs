using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class JumpController : MonoBehaviour {

	public float jumpSpeed;
	private bool isJumping;
	private bool Jumped;

	private float floorHeight;

	void Start(){
		isJumping = false;
		Jumped = false;
	}
	
	void Update () {
		if(CrossPlatformInputManager.GetAxis("Jump") > 0){
			if(!isJumping){
				Debug.Log("Jumped");
				// floorHeight = transform.position.y;
				var rotation = transform.rotation;
				GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
				transform.rotation = rotation;
				// Jumped = true;
				isJumping = true;
			}
		} else {
			isJumping = false;
		}
	}
}
