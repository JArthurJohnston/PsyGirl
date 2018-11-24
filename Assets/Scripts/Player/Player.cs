using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public AbstractPower[] powers;

	public static Resources Resources {get; private set;}

	void Start(){
		Resources = GetComponent<Resources>();
	}

	void swapPowers(){
	}

}
