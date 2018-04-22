using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction {
	public Chassis attacker;
	public Chassis target;
	public virtual void Execute(){}
}
public class FinishAttack:PlayerAction{
	public override void Execute(){
		GameManager.Attacks(attacker,target);
	}
}
public class AssignDice:PlayerAction{
	ChassisSystem frame;
	ChassisSystem chassisSystem;
	public override void Execute(){
		attacker.assignWildDice(frame,chassisSystem);
	}

}
