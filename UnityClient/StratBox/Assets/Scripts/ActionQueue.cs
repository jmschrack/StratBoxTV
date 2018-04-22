using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQueue : MonoBehaviour {

	public static ActionQueue instance;
	Queue<RequestAction> outboundQueue;
	Queue<PlayerAction> inboundQueue;
	void Awake(){
		if(instance==null)
			instance=this;
		else if(instance!=this)
			Destroy(this);
	}
	void OnDestroy(){
		if(instance==this)
			instance=null;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	bool HasRequest(){
		lock(outboundQueue){
			return outboundQueue.Count>0;
		}
	}
	void MakeRequest(RequestAction requestAction){
		lock(outboundQueue){
			outboundQueue.Enqueue(requestAction);
		}
	}
	RequestAction GetRequest(){
		lock(outboundQueue){
			return outboundQueue.Dequeue();
		}
	}

	bool HasResponse(){
		lock(inboundQueue){
			return inboundQueue.Count>0;
		}
	}

	PlayerAction GetResponse(){
		lock(inboundQueue){
			return inboundQueue.Dequeue();
		}
	}
	public void AddResponse(PlayerAction playerAction){
		lock(inboundQueue){
			inboundQueue.Enqueue(playerAction);
		}
	}

	public void RequestActivation(Squad player){
		RequestAction temp = new RequestAction(RequestAction.RequestType.activation,player,null);
		MakeRequest(temp);
	}
	public void RequestDefenseActivation(Squad player, Chassis unit){
		RequestAction temp = new RequestAction(RequestAction.RequestType.defenceActivation,player,unit);
		MakeRequest(temp);
	}

	public void RequestDiceAssign(Squad player, Chassis unit){
		RequestAction temp = new RequestAction(RequestAction.RequestType.diceAssign,player,unit);
		MakeRequest(temp);
	}

	public void RequestPlayerAction(Squad player){
		RequestAction temp = new RequestAction(RequestAction.RequestType.playerAction,player,null);
		MakeRequest(temp);
	}
}
public class RequestAction{
	public enum RequestType{
		activation,
		defenceActivation,
		diceAssign,
		playerAction
	}
	public RequestAction(RequestType requestType,Squad player, Chassis unit){
		this.requestAction=requestType;
		this.player=player;
		this.unit=unit;
	}
	public RequestType requestAction;
	public Squad player;
	public Chassis unit;
}