using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static Resources Resources {get; private set;}
	public static Player Main;

	public float LightLevel {get; set;}

	public PowerMap Powers {get; private set;}
	public GameObject Selection {get; set;}

	void Start(){
		Resources = GetComponent<Resources>();
		Powers = GetComponent<PowerMap>();
		Main = this;
	}



}
