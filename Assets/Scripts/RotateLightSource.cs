using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLightSource : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	float x;
	float y;
	float z;
	// Update is called once per frame
	void Update () {
		// Plagiarized from https://docs.unity3d.com/Manual/QuaternionAndEulerRotationsInUnity.html
		// rotation scripting with Euler angles correctly.
		// here we store our Euler angle in a class variable, and only use it to
		// apply it as a Euler angle, but we never rely on reading the Euler back.
		x += Time.deltaTime * 10;
		y += Time.deltaTime * 30;
		z += Time.deltaTime * 20;
		transform.rotation = Quaternion.Euler(x,y,z);

	}
}
