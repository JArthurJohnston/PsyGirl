using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour {

	public bool enabled;
	
	void Update () {
		if(enabled){
			logKeysAndButtonPresses();
			//Input.GetAxis("Attack2") > 0 || Input.GetAxis("Attack1") > 0
			Debug.Log("Trigger? :" + Input.GetAxis("Attack1"));
			// Debug.Log(Input.GetAxis("Attack2"));
		}
	}

	/**
		Does Not log joystick or trigger inputs
		Will log mouse clicks
	*/
	void logKeysAndButtonPresses(){
		if(Input.anyKey){
			Debug.Log(Input.inputString);
		}
	}
}
