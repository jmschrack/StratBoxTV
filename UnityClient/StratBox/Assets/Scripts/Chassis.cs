using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chassis : MonoBehaviour {
	public ChassisSystem attackSystem;
	public ChassisSystem defendSystem;
	public ChassisSystem moveSystem;
	public ChassisSystem sensorSystem;
	
	public ChassisSystem frame1;
	public ChassisSystem frame2;
	
	public bool activated;
	public bool isAlive;

	public void ActivateUnit(){
		if(activated){
			return;
		}

		GameManager.rollDice(this);

		activated=true;
	}

	public void assignWildDice(ChassisSystem frame, ChassisSystem assignedTo){
		assignedTo.currentValue=frame.currentValue;
	}

	public void Attack(Chassis enemy){
		
	}

}
