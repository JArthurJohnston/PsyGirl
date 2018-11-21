using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

	public PauseMenu menu;
	float DefaultTimeScale;

	bool IsPaused;
	bool buttonPressed;
	void Start () {
		IsPaused = false;
		buttonPressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Pause") > 0){
			buttonPressed = true;
		} else if (buttonPressed) {
			buttonPressed = false;
			if(IsPaused){
				ResumeGame();
			} else {
				PauseGame();
			}
		}
	}

	void PauseGame(){
		// DefaultTimeScale = Time.timeScale;
		IsPaused = true;
		menu.Show();
		Time.timeScale = 0;
	}

	void ResumeGame(){
		Time.timeScale = 1;
		IsPaused = false;
		menu.Hide();
	}
}
