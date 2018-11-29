using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceHoldController : AbstractPowerController
{
    private bool HoldingSomething;
    private Transform heldObject;
    public float Lift;
    public float HeightLimit;
    private float MaxHeight;
    public override void Initialize()
    {
        HoldingSomething = false;
    }

    public override void Handle(float input)
    {
		if(input > 0){
			if(!HoldingSomething)
				PickUp();
		} else {
			if(HoldingSomething)
				Drop();
		}   
    }

    void Update(){
        if(heldObject != null){
            if(heldObject.transform.position.y < MaxHeight){
                heldObject.GetComponent<Rigidbody>().velocity = Vector3.up * Lift;
            }
        }
    }

    private void PickUp(){
        HoldingSomething = true;
        if(Player.Main.Selection != null){
            heldObject = Player.Main.Selection.transform;
            heldObject.transform.parent = transform;
            MaxHeight = heldObject.position.y + HeightLimit;
        }
    }

    private void Drop(){
        HoldingSomething = false;
        if(heldObject != null){
            heldObject.transform.parent = Environment.Main.transform;
            heldObject = null;
        }
    }
}
