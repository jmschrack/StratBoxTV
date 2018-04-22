using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FakeServer : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PullFromQueue();
	}

	void PullFromQueue(){
		if(ActionQueue.instance.HasRequest()){
			RequestAction ra = ActionQueue.instance.GetRequest();
		}
		

	}
}
