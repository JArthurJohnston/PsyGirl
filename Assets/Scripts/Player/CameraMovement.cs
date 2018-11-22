using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public float horizontalSeed;
	public float verticalSpeed;
	public float distanceToPlayer;
	public float maxHeight;
	public float minHeight;
	public float heightOffset;
	public GameObject playerBody;

	float totalRotation;

	void Start(){
		totalRotation = 0;
	}

	void Update () {
		/*
		TODO: make the camera rotate with the player. the speed of the rotation to be relative to the distance of the camera to the player
		this is less necessary now that the attacks have been mapped to the trigger buttons, but may be needed as I map more things to
		the controller buttons
		 */
		var playerPosition = playerBody.transform.position;
		transform.position = new Vector3(playerPosition.x, transform.position.y, playerPosition.z - distanceToPlayer);
        RotateCameraAroundPlayer();
		ApplyVerticalMovement();
		Camera.main.transform.LookAt(new Vector3(playerPosition.x, playerPosition.y + heightOffset, playerPosition.z));
	}

	void ApplyVerticalMovement(){
		var verticalInput = Input.GetAxis("Vertical2");
        if(verticalInput != 0){
			var verticalMovement = verticalInput * verticalSpeed * Time.deltaTime;
			updateCameraHeight(verticalMovement);
		}
	}

	void RotateCameraAroundPlayer(){
		//this is actually constantly rotating the camera, the lookat call is correcting this, but it still sucks that
		//its performing all this unnecessary math...
		var horizontalInput = Input.GetAxis("Horizontal2");
		// if(horizontalInput != 0){
			var horizontalMovement = horizontalInput * horizontalSeed * Time.deltaTime;
			totalRotation += horizontalMovement;
			transform.RotateAround(playerBody.transform.position, transform.up, totalRotation);
		// }
	}

	void updateCameraHeight(float delta){
		transform.Translate(Vector3.up * delta);
		transform.position = new Vector3(transform.position.x, cameraHeight(), transform.position.z); 
	}

	float cameraHeight(){
		var currentPosition =  playerBody.transform.position.y;
		return Mathf.Clamp(transform.position.y, currentPosition - minHeight, currentPosition + maxHeight);
	}
}
