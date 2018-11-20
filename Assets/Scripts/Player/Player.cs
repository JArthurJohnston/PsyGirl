using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static Resources Resources {get; private set;}

	void Start(){
		Resources = GetComponent<Resources>();
	}

}
