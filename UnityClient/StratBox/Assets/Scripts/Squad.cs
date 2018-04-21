using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad : MonoBehaviour {
	public List<Chassis> units;
	public int score;
	public int assetMultiplier=5;
	
	public void recalculateScore(){
		int score=0;
		foreach(Chassis c in units){
			if(c!=null&&c.isAlive){
				score+=assetMultiplier;
			}
		}
		this.score=score;
	}

	public void newTurn(){
		foreach(Chassis c in units){
			if(c==null)
				continue;
			c.activated=false;
		}
		recalculateScore();
	}
	public bool hasUnitsLeft(){
		foreach(Chassis c in units){
			if(c.isAlive&&!c.activated)
				return true;
		}
		return false;
	}

	public int GetChassisCount(){
		int i=0;
		foreach(Chassis c in units){
			if(c!=null&&c.isAlive)
				i++;
		}
		return i;
	}
	public int GetSystemCount(){
		int i=0;
		foreach(Chassis c in units){
			if(c==null)
				continue;
			i+=(c.attackSystem!=null?1:0);
			i+=(c.defendSystem!=null?1:0);
			i+=(c.sensorSystem!=null?1:0);
			i+=(c.moveSystem!=null?1:0);
		}
		return i;
	}
}
