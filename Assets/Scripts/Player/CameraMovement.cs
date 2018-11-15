using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public float speed;
	public GameObject playerBody;

	void Update () {
        var horizontalMovement = Input.GetAxis("Horizontal2") * speed * Time.deltaTime;
        var verticalMovement = Input.GetAxis("Vertical2") * speed * Time.deltaTime;

		transform.RotateAround(playerBody.transform.position, Vector3.up, horizontalMovement);
		transform.RotateAround(playerBody.transform.position, Vector3.right, verticalMovement);
		
		Debug.Log("Looking At: " + playerBody.transform.position);
		Camera.main.transform.LookAt(playerBody.transform.position);
		// transform.LookAt(playerBody.transform.position);
	}
}
