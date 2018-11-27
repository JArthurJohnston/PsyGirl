using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour {

	public float lookOffset;

	public GameObject pointer;

	void FixedUpdate () {
		var playerTransform = Player.Main.transform;
		var playerHeadPosition = playerTransform.position + (playerTransform.up * lookOffset);
		var pointerDirection = playerHeadPosition - Camera.main.transform.position;
		// pointerDirection = pointerDirection/pointerDirection.magnitude; //normalized direction?

		var ray = new Ray(Camera.main.transform.position, pointerDirection);
		Debug.DrawRay(Camera.main.transform.position, pointerDirection, Color.green);
		
		RaycastHit hit;

        if(RayHelper.Cast(ray, out hit, 100f, RayHelper.allButLayerMask("Player"))){
			Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.cyan);

			pointer.transform.position = hit.transform.position;
        }
	}
}
