using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

	int time;
	public GameObject Fireball;
	public string direction;
	public int lifetime;
	public int period;

	// Use this for initialization
	void Start () {
		time = 0;
	}


	Vector3 fireballOffset()
	{
		switch (direction) {
		case "up":
			return new Vector3 (0f, 0.7f, 0f);
		case "down":
			return new Vector3 (0f, -0.7f, 0f);
		case "left":
			return new Vector3 (-0.7f, 0f, 0f);
		case "right":
			return new Vector3 (0.7f, 0f, 0f);
		}

		// should never reach this point on valid inputs
		return new Vector3 (0f, 0f, 0f);
	}

	// Update is called once per frame
	void Update () {
		time++;

		if(time % period == 0){
			GameObject fireball = Instantiate (Fireball, transform.position + fireballOffset(), Quaternion.identity);
			fireball.GetComponent<FireballMover>().direction = direction;
			fireball.GetComponent<FireballMover>().lifetime = lifetime;
			fireball.GetComponent<FireballMover>().active = true;
			fireball.GetComponent<FireballMover>().enabled = true;
			time = 0;
		}
	}

	void OnRestart(){
		time = 0;
	}

}
