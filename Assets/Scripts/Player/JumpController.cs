using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour {

	public float jumpSpeed;
	private bool isJumping;

	void Start(){
		isJumping = false;
	}
	
	void Update () {
		if(Input.GetAxis("Jump") > 0){
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
