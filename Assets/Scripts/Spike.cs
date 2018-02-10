using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

	public bool triggered;

	// Use this for initialization
	void Start () {
		triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(){
		triggered = true;
		GameObject.Find("Player").SendMessage("RestartAll");
	}
}
