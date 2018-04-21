using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<Squad> players;
	public List<Squad> tacticalOrder;
	public List<Squad> combatOrder;
	public int currentTacticalPlayer;

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

	public void newTurn(){
		foreach(Squad s in players){
			s.newTurn();
		}
		tacticalOrder= new List<Squad>();
		tacticalOrder.AddRange(players);
		tacticalOrder.Sort(delegate(Squad a, Squad b) {
			return -1*a.score.CompareTo(b.score);
		});
		currentTacticalPlayer=-1;
		combatOrder= new List<Squad>();
		nextPlayer();
	}

	public void nextPlayer(){
		if(combatOrder.Count>0){
			//combat stuff
		}else{
			int lastIndex=currentTacticalPlayer;
			
			do{
				currentTacticalPlayer=(currentTacticalPlayer+1)%tacticalOrder.Count;
			}while(currentTacticalPlayer!=lastIndex&&!tacticalOrder[currentTacticalPlayer].hasUnitsLeft());
			if(!tacticalOrder[currentTacticalPlayer].hasUnitsLeft()){
				//everyone is done
				newTurn();
			}else{
				
				//next player stuff
			}
		}
	}

	void Start(){
		StartGame();
	}

	public void StartGame(){
		calculatePlayersAssetScore();
		foreach(Squad s in players){
			s.recalculateScore();
		}
		players.Sort(delegate(Squad a, Squad b){
			return a.score.CompareTo(b.score);
		});
		newTurn();

	}

	void calculatePlayersAssetScore(){
		players.Sort(delegate(Squad a, Squad b){
			return (a.GetChassisCount().CompareTo(b.GetChassisCount()));
		});
		bool process=true;
		Debug.Log("Chassis Bonus to "+players[0].name);
		players[0].assetMultiplier++;
		int i=1;
		//give bonus for lowest count
		do{
			if(players[i].GetChassisCount()==players[0].GetChassisCount()){
				players[i].assetMultiplier++;
				Debug.Log("Chassis Bonus to "+players[i].name);
			}else
				process=false;
			i++;
		}while(i<players.Count&&process);

	
		//give penalty for highest count
		players.Reverse();
		Debug.Log("Penalty to "+players[0].name);
		players[0].assetMultiplier--;
		i=1;
		//give bonus for lowest count
		do{
			if(players[i].GetChassisCount()==players[0].GetChassisCount()){
				players[i].assetMultiplier--;
				Debug.Log("Chassis Penalty to "+players[i].name);
			}else
				process=false;
			i++;
		}while(i<players.Count&&process);


		players.Sort(delegate(Squad a, Squad b){
			return a.GetSystemCount().CompareTo(b.GetSystemCount());
		});
		Debug.Log("System Bonus to "+players[0].name+":"+players[0].GetSystemCount());
		players[0].assetMultiplier++;
		i=1;
		//give bonus for lowest count
		do{
			if(players[i].GetSystemCount()==players[0].GetSystemCount()){
				players[i].assetMultiplier++;
				Debug.Log("System Bonus to "+players[i].name+":"+players[i].GetSystemCount());
			}else
				process=false;
			i++;
		}while(i<players.Count&&process);



		//give penalty for highest count
		players.Reverse();
		Debug.Log("System Penalty to "+players[0].name);
		players[0].assetMultiplier--;
		i=1;
		//give bonus for lowest count
		do{
			if(players[i].GetSystemCount()==players[0].GetSystemCount()){
				players[i].assetMultiplier--;
				Debug.Log("System Penalty to "+players[i].name);
			}else
				process=false;
			i++;
		}while(i<players.Count&&process);

	
	}


}
