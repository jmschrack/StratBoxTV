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
public class ActivateUnit:PlayerAction{
	public override void Execute(){
		GameManager.rollDice(attacker);
		ActionQueue.instance.RequestDiceAssign(GameManager.GetChassisOwner(attacker),attacker);
	}
}
public class AssignDice:PlayerAction{
	public ChassisSystem frame;
	public ChassisSystem chassisSystem;
	public override void Execute(){
		attacker.assignWildDice(frame,chassisSystem);
	}

}
