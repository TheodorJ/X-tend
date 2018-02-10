using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWall : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy(){
		this.tag = "Deleted";
		player.BroadcastMessage("updateWalls");
		GetComponent<BoxCollider>().enabled = false;
		GetComponent<MeshRenderer>().enabled = false;
	}

	void OnRestart(){
		this.tag = "Wall";
		GetComponent<BoxCollider>().enabled = true;
		GetComponent<MeshRenderer>().enabled = true;
	}
}
