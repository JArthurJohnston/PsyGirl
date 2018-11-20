using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBlast : MonoBehaviour {

	public float ExpansionSpeed;
	public float TimeToLive;

	public float Force {get; set;}

	// Use this for initialization
	void Start () {
		Destroy(gameObject, TimeToLive);
	}
	
	// Update is called once per frame
	void Update () {
		var expanded = Time.deltaTime * ExpansionSpeed;
		transform.localScale += new Vector3(expanded, expanded, expanded);
	}
}
