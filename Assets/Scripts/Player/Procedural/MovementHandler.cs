using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovementHandler : MonoBehaviour {

	public float speed;
	public GameObject CameraHolder;
	private ProceduralMovementController movementController;

	void Start() {
		movementController = GetComponent<ProceduralMovementController>();
	}

	// Update is called once per frame
	void Update () {
		var horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
		var verticalInput = CrossPlatformInputManager.GetAxis("Vertical") * speed;
		var forwardDirection = CameraHolder.transform.rotation;

		var playerMovement = new Vector3(horizontalInput, 0.0f, verticalInput);
		movementController.MovePlayer(forwardDirection * playerMovement);
	}
}
