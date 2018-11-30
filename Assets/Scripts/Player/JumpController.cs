using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class JumpController : MonoBehaviour {

	public float jumpSpeed;
	private bool isJumping;
	private bool Jumped;

	void Start(){
		isJumping = false;
	}
	
	void Update () {
		if(CrossPlatformInputManager.GetAxis("Jump") > 0){
			if(!isJumping){
				var rotation = transform.rotation;
				GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
				transform.rotation = rotation;
				isJumping = true;
			}
		} else {
			isJumping = false;
		}
	}
}
