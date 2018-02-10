using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

	public string nextScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.name == "Player"){
			SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
		}

	}
}
