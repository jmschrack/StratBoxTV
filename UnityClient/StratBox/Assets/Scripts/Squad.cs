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
			if(c.isAlive){
				score+=assetMultiplier;
			}
		}
		this.score=score;
	}
}
