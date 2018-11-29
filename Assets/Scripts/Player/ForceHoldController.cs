using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceHoldController : AbstractPowerController
{
    private bool HoldingSomething;
    private Transform targetParent;

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

    private void PickUp(){
        targetParent =  Player.Main.Selection.transform.parent;
        Player.Main.Selection.transform.parent = Player.Main.transform;
    }

    private void Drop(){
        Player.Main.Selection.transform.parent = targetParent;
    }
}
