using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMovementController : MonoBehaviour {

    public float turningSpeed;
    public GameObject characterBody;

    void Update(){
    }

    public void MovePlayer(Vector3 movement){
        RotatePlayer(movement);
        GetComponent<Rigidbody>().velocity = movement * Time.deltaTime;
        // transform.Translate(movement * Time.deltaTime, Space.World);
    }

    public void RotatePlayer(Vector3 movement){
		if (movement != Vector3.zero){
			characterBody.transform.rotation = Quaternion.Slerp(
				characterBody.transform.rotation, Quaternion.LookRotation(movement), turningSpeed);
		}
	}
}
