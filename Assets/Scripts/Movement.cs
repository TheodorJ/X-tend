using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Vector3[] movementCoordinates;
    public int movementPeriod;

    private int movementPhase = 0;
    private Vector3 movementVector;
    public Rigidbody rb;

    private int mvmtCount = 0;
    private float epsilon = 0.000001f;

	// Use this for initialization
	void Start () {
        transform.position = movementCoordinates[0];
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        int len = movementCoordinates.Length;
		if (mvmtCount == 0)
        {
            print("Phase changed");
            movementVector = (movementCoordinates[(movementPhase + 1) % len] -
				movementCoordinates[movementPhase]) / movementPeriod;
			movementPhase = (movementPhase + 1) % len;
        }

        rb.MovePosition(transform.position + movementVector);
        mvmtCount = (mvmtCount + 1) % movementPeriod;
	}
}
