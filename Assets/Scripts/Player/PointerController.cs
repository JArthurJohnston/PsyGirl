using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour {

	public float lookOffset;

	public GameObject pointer;

	private int selectionMask;
	private static Vector3 defaultPointerPosition = new Vector3(0,-1,0);

	void Start(){
		selectionMask = LayerMask.GetMask("Moveable", "Visible");
	}

	void FixedUpdate () {
		var playerTransform = Player.Main.transform;
		var playerHeadPosition = playerTransform.position + (playerTransform.up * lookOffset);
		var pointerDirection = playerHeadPosition - Camera.main.transform.position;

		RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, pointerDirection, out hit, 100f, selectionMask)){
			Player.Main.Selection = hit.transform.gameObject;
			pointer.transform.position = hit.transform.position;
        } else {
			pointer.transform.position = defaultPointerPosition;
			Player.Main.Selection = null;
		}
	}
}
