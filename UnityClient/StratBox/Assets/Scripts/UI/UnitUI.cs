using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitUI : MonoBehaviour {
	public Text unitName;
	public Text attackSystem;
	public Text defenceSystem;
	public Text sensorSystem;
	public Text movementSystem;
	Chassis chassis;
	public delegate void UnitUIDelegate(Chassis chassis);
	public event UnitUIDelegate OnClick;
	
	public void Init(Chassis chassis){
		this.chassis=chassis;
		unitName.text=chassis.name;
		attackSystem.text=createSystemText(chassis.attackSystem);
		defenceSystem.text=createSystemText(chassis.defendSystem);
		sensorSystem.text=createSystemText(chassis.sensorSystem);
		movementSystem.text=createSystemText(chassis.moveSystem);

	}
	string createSystemText(ChassisSystem cs){
		return cs.name+":"+cs.currentValue;
	}
	public void clickEvent(){
		OnClick(chassis);
	}
}
