using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public float horizontalSeed;
	public float verticalSpeed;
	public float maxHeight;
	public float minHeight;
	public float heightOffset;
	public GameObject playerBody;

	void Update () {
		/*
		TODO: make the camera rotate with the player. the speed of the rotation to be relative to the distance of the camera to the player
		this is less necessary now that the attacks have been mapped to the trigger buttons, but may be needed as I map more things to
		the controller buttons
		 */
        var horizontalMovement = Input.GetAxis("Horizontal2") * horizontalSeed * Time.deltaTime;
        var verticalMovement = Input.GetAxis("Vertical2") * verticalSpeed * Time.deltaTime;

		transform.RotateAround(playerBody.transform.position, transform.up, horizontalMovement);
		updateCameraHeight(verticalMovement);
		
		var position = playerBody.transform.position;
		Camera.main.transform.LookAt(new Vector3(position.x, position.y + heightOffset, position.z));
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
