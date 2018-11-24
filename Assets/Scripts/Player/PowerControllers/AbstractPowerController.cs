using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPowerController : MonoBehaviour {

    class NullPower : AbstractPowerController {

        public override void Initialize(){
            
        }
        public override void Handle(float input){
            //Does Nothing
        }
    }

    
    public static AbstractPowerController NO_POWER;

    public abstract void Handle(float input);
    public abstract void Initialize();
}