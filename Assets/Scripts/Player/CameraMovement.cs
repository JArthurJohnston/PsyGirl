using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public float speed;
	public GameObject playerBody;

	void Update () {
        var movement = Input.GetAxis("Horizontal2") * speed * Time.deltaTime;
		transform.RotateAround(playerBody.transform.position, Vector3.up, movement);
	}
}
