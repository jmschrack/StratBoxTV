using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FakeServer : MonoBehaviour {
	public RectTransform uiPanel;
	public PlayerUI playerUIPrefab;
	bool waitForInput;

	//references lol
	PlayerAction currentAction;

	// Use this for initialization
	void Start () {
		CreateUIStuff();
	}

	void CreateUIStuff(){
		foreach(Squad s in GameManager.instance.players){
			PlayerUI temp = Instantiate(playerUIPrefab,uiPanel);
			temp.Init(s);
			temp.OnClick+=clickEvent;
		}
	}

	void clickEvent(Squad player, Chassis unit){
		if(waitForInput){
			if(currentAction.attacker==null)
				currentAction.attacker=unit;
			else
				currentAction.target=unit;
			ActionQueue.instance.AddResponse(currentAction);
			waitForInput=false; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		PullFromQueue();
	}

	void PullFromQueue(){
		if(ActionQueue.instance.HasRequest()){
			RequestAction ra = ActionQueue.instance.GetRequest();
			switch(ra.requestAction){
				case RequestAction.RequestType.activation:
					currentAction = new ActivateUnit();
					waitForInput=true;
				break;
			}
		}
		

	}
}
