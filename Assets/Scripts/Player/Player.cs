using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static Resources Resources {get; private set;}
	public static Player Main;

	void Start(){
		Resources = GetComponent<Resources>();
		Main = this;
	}

	void swapPowers(){
	}

}
