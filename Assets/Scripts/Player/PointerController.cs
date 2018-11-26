using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour {

	public float lookOffset;

	public GameObject pointer;

	void FixedUpdate () {
		var playerTransform = Player.Main.transform;
		var ray = new Ray(playerTransform.position + (playerTransform.up * lookOffset), Camera.main.transform.forward);

		Debug.DrawRay(playerTransform.position + (playerTransform.up * lookOffset), Camera.main.transform.forward, Color.green);
		RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100f)){
			Debug.DrawLine(playerTransform.position + (playerTransform.up * lookOffset), hit.transform.position, Color.cyan);
			pointer.transform.position = hit.transform.position;
        }
		
	}
}
