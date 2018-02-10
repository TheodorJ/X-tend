using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMover : MonoBehaviour {

	GameObject cannon;
	GameObject player;
	public string direction;
	int time;
	public int lifetime;
	public bool active = false;

	// Use this for initialization
	void Start () {
		time = 0;
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		time++;
		if(active && time >= lifetime){
			print ("Destroyed fireball (time)");
			Destroy(this.gameObject);
		}
		switch(direction){
			case "up":
				transform.position += new Vector3(0f,0.2f,0f);
				break;
			case "down":
				transform.position += new Vector3(0f,-0.2f,0f);
				break;
			case "left":
				transform.position += new Vector3(-0.2f,0f,0f);
				break;
			case "right":
				transform.position += new Vector3(0.2f,0f,0f);
				break;
		}

	}

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag == "Player"){
			player.SendMessage("RestartAll");
		}
		Destroy(this.gameObject);
	}

	void OnRestart(){
		if(active){
			print ("Destroyed fireball");
			Destroy(this.gameObject);
		}
	}
}
