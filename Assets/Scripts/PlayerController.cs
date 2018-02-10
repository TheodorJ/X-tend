using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
	public Vector3 startLocation;

    // Use this for initialization
    void Start()
    {
		transform.position = startLocation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity.Set(0, 0, 0);
        

        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.MovePosition(transform.position + (new Vector3(0.1f, 0, 0)));
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.MovePosition(transform.position - (new Vector3(0.1f, 0, 0)));
        }
        
		if (Input.GetKeyDown (KeyCode.R))
			RestartAll ();
    }

	void RestartAll(){
		GameObject[] objects = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
		foreach(GameObject object1 in objects){
			object1.SendMessage("OnRestart");
		}
	}

	void OnRestart(){
		transform.position = startLocation;
	}


}
