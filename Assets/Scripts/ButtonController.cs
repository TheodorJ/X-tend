using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public bool triggered;
	public GameObject destroyOnTrigger;

	// Use this for initialization
	void Start () {
		triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(){
		triggered = true;
		destroyOnTrigger.BroadcastMessage("OnDestroy");
		GetComponent<MeshRenderer>().enabled = false;
	}

	void OnRestart(){
		triggered = false;
		GetComponent<MeshRenderer>().enabled = true;
	}
}
