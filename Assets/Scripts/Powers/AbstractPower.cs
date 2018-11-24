using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPower : MonoBehaviour
{
    public float ChargePerSecond;
    public float Cost;
    public string DisplayName;
    public float Force {get; set;}
}