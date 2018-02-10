using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extend : MonoBehaviour {

    public string armOrientation;
	public GameObject oppositeArm;
    public Vector3 offset;
    public Vector3 scaleVector;
    public KeyCode activationKey;
    public GameObject player;
	public Collider collider;
	public GameObject[] walls;

    private KeyCode retractTrigger = KeyCode.LeftShift;
    private Vector3 scaleLimit = new Vector3(4, 4, 4);

	void Start(){
		collider = GetComponent<Collider>();
		walls = GameObject.FindGameObjectsWithTag("Wall");
	}

	void updateWalls(){
		walls = GameObject.FindGameObjectsWithTag("Wall");
	}

    // checks if arm has not exceeded the scale limit
	bool isTouchingWall(Collider coll){
		foreach (GameObject wall in walls) {
			if (coll.bounds.Intersects (wall.GetComponent<Collider>().bounds)) {
				return true;
			}
		}
		return false;
	}

    bool isSafeToExtend()
    {
		if (isTouchingWall(collider) && isTouchingWall(oppositeArm.GetComponent<Collider>()))
			return false;

        Vector3 currentScale = transform.localScale;
		return (System.Math.Abs(currentScale.x) < scaleLimit.x) &&
               (System.Math.Abs(currentScale.y) <= scaleLimit.y);
    }

    // checks if arm has not reached 0 scale
    bool isSafeToRetract()
    {
        Vector3 currentScale = transform.localScale;
        switch (armOrientation) {
            case "up":
				return currentScale.y > 2 * scaleVector.magnitude;
            case "right":
				return currentScale.x > 2 * scaleVector.magnitude;
			case "down":
				return -(currentScale.y) > 2 * scaleVector.magnitude;
            case "left":
				return -(currentScale.x) > 2 * scaleVector.magnitude;
            default:
                return false;
        }
    }

    bool isTopRight()
    {
        return (armOrientation == "up" || armOrientation == "right");
    }

    // extend arm outward
    void extendArm()
    {
        if (isSafeToExtend())
        {
			if (activationKey == KeyCode.S)
            {
                player.GetComponent<Rigidbody>().MovePosition(player.transform.position + scaleVector);
                transform.localScale += scaleVector;
            }
			else
            {
                transform.localScale += scaleVector;
            }

            offset = offset + 0.5f * scaleVector;
        }
    }

    // retract arm inward
    void retractArm()
    {
        if (isSafeToRetract())
        {
            transform.localScale -= scaleVector;

            offset = offset - 0.5f * scaleVector;
        }
    }

	// Update is called once per frame
	void Update () {



        // Control scheme where a button extends an arm, and that button with 
        // shift retracts the SAME arm
        if (Input.GetKey(activationKey))
        {
            if (Input.GetKey(retractTrigger))
                retractArm();
            else
                extendArm();
        }

        transform.position = player.transform.position + offset;

    }

	void OnRestart(){
		switch (armOrientation) {
		case "up":
			transform.localScale = new Vector3 (0.5f, 0f, 1f) + 4 * scaleVector;
			break;
		case "right":
			transform.localScale = new Vector3(0f,0.5f,1f) + 4*scaleVector;
			break;
		case "down":
			transform.localScale = new Vector3(0.5f,0f,1f) + 4*scaleVector;
			break;
		case "left":
			transform.localScale = new Vector3(0f,0.5f,1f) + 4*scaleVector;
			break;
		}
		transform.position = player.transform.position + 10*scaleVector;
		offset = 10 * scaleVector;
	}


}
