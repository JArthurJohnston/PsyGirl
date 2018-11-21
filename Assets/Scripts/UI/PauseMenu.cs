using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static PauseMenu Main;

	// Use this for initialization
	void Start () {
		Main = this;
	}
	
	public void Show(){
		gameObject.SetActive(true);
	}

	public void Hide(){
		gameObject.SetActive(false);
	}
}
