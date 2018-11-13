using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	public float turningSpeed;
	public GameObject playerBody;

	public GameObject cameraHolder;
	
	// Update is called once per frame
	void Update () {
		this.Move();
	}

	void Move(){
		var movement = getMovementFromInput();
		rotatePlayer(movement);
        transform.Translate(movement * Time.deltaTime, Space.World);
	}

	Vector3 getMovementFromInput(){
        var x = Input.GetAxis("Horizontal") * speed;
        var z = Input.GetAxis("Vertical") * speed;
		var playerMovement = new Vector3(x, 0.0f, z);
 		return cameraHolder.transform.rotation * playerMovement;
	}

	void rotatePlayer(Vector3 movement){
		if (movement != Vector3.zero){
			playerBody.transform.rotation = Quaternion.Slerp(
				playerBody.transform.rotation, Quaternion.LookRotation(movement), turningSpeed);
		}
	}

}
