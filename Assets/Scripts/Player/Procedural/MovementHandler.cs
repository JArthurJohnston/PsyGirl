using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovementHandler : MonoBehaviour {

	public float speed;
	public float jumpPower;
	public GameObject CameraHolder;
	private ProceduralMovementController movementController;

	void Start() {
		movementController = GetComponent<ProceduralMovementController>();
	}

	void FixedUpdate () {
		var horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
		var verticalInput = CrossPlatformInputManager.GetAxis("Vertical") * speed;
		var jump = CrossPlatformInputManager.GetButtonDown("Jump") ? jumpPower : 0f;

		var forwardDirection = CameraHolder.transform.rotation;
		var playerMovement = forwardDirection * new Vector3(horizontalInput, 0f, verticalInput);

		movementController.MovePlayer(playerMovement, jump);
	}
}
