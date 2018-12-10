using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraMovementHandler : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		RotateAroundPlayer( CrossPlatformInputManager.GetAxis("Horizontal2"));
		UpdateCameraHeight(CrossPlatformInputManager.GetAxis("Vertical2"));
	}

	void RotateAroundPlayer(float angle){
		transform.RotateAround(Player.Main.transform.position, Vector3.up, angle);
		Camera.main.transform.LookAt(Player.Main.transform, Vector3.up);
	}

	void UpdateCameraHeight(float delta){
		transform.Translate(Vector3.up * delta);
		// transform.position = new Vector3(transform.position.x, cameraHeight(), transform.position.z); 
	}
}
