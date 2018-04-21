using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	


	public static void rollDice(Chassis unit){
		rollDice(unit.defendSystem);
		rollDice(unit.attackSystem);
		rollDice(unit.sensorSystem);
		rollDice(unit.moveSystem);
		rollDice(unit.frame1);
		rollDice(unit.frame2);
	}

	public static void rollDice(ChassisSystem cs){
		cs.currentValue=0;
		for(int i=0;i<cs.d6;i++){
			cs.currentValue=Mathf.Max(cs.currentValue,Random.Range(1,6));
		}
		for(int i=0;i<cs.d8;i++){
			cs.currentValue=Mathf.Max(cs.currentValue,Random.Range(1,8));
		}
	}
}
