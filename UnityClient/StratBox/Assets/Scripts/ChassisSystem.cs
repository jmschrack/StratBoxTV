using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChassisSystem : MonoBehaviour {
    public SystemType type;
    public string partName;
    public int d6;
    public int d8;
    public int currentValue;
    public bool isDestroyed;
}

public enum SystemType{
    attack,
    defend,
    move,
    sensor,
    frame
}
