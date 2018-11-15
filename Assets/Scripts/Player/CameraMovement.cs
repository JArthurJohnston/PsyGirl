using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public float horizontalSeed;
	public float verticalSpeed;
	public float maxHeight;
	public float minHeight;
	public GameObject playerBody;

	void Update () {
        var horizontalMovement = Input.GetAxis("Horizontal2") * horizontalSeed * Time.deltaTime;
        var verticalMovement = Input.GetAxis("Vertical2") * verticalSpeed * Time.deltaTime;

		transform.RotateAround(playerBody.transform.position, transform.up, horizontalMovement);
		updateCameraHeight(verticalMovement);
		Camera.main.transform.LookAt(playerBody.transform.position);
	}

	void updateCameraHeight(float delta){
		transform.Translate(Vector3.up * delta);
		transform.position = new Vector3(transform.position.x, cameraHeight(), transform.position.z); 
	}

	float cameraHeight(){
		return Mathf.Clamp(transform.position.y, minHeight, maxHeight);
	}
}
