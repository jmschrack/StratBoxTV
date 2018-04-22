using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
------------
Custom Inspector
------------
 */

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(ActionQueue))]
public class ActionQueueUI : Editor{
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		ActionQueue actionQueue=(ActionQueue)target;
		EditorGUILayout.LabelField("Outbound Queue:"+actionQueue.GetRequestCount());
		EditorGUILayout.LabelField("Inbound Queue:"+actionQueue.GetResponseCount());
	}
}
#endif



/*
-----------------
Actual code
-----------------
 */


public class ActionQueue : MonoBehaviour {

	public static ActionQueue instance;
	Queue<RequestAction> outboundQueue;
	int outboundQueueCount=0;
	int inboundQueueCount=0;
	Queue<PlayerAction> inboundQueue;
	void Awake(){
		if(instance==null){
			instance=this;
			outboundQueue= new Queue<RequestAction>();
			inboundQueue= new Queue<PlayerAction>();
		}else if(instance!=this)
			Destroy(this);
	}
	void OnDestroy(){
		if(instance==this)
			instance=null;
	}
	
	public bool HasRequest(){
			return outboundQueueCount>0;
	}
	public int GetRequestCount(){
		return outboundQueueCount;
	}
	void MakeRequest(RequestAction requestAction){
		lock(outboundQueue){
			outboundQueue.Enqueue(requestAction);
			outboundQueueCount=outboundQueue.Count;
		}
	}
	public RequestAction GetRequest(){
		lock(outboundQueue){
			outboundQueueCount=outboundQueue.Count-1;
			return outboundQueue.Dequeue();
		}
	}

	public bool HasResponse(){
			return inboundQueueCount>0;
	}
	public int GetResponseCount(){
		return inboundQueueCount;
	}

	public PlayerAction GetResponse(){
		lock(inboundQueue){
			inboundQueueCount=inboundQueue.Count-1;
			return inboundQueue.Dequeue();
		}
	}
	public void AddResponse(PlayerAction playerAction){
		lock(inboundQueue){
			inboundQueue.Enqueue(playerAction);
			inboundQueueCount=inboundQueue.Count;
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

	public void RequestPlayerAction(Squad player,Chassis unit){
		RequestAction temp = new RequestAction(RequestAction.RequestType.playerAction,player,unit);
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