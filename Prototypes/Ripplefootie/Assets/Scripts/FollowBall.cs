using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {

    //target gameobject reference
    public GameObject ballTarget;
    public bool lookAtBall = false;


	// Use this for initialization
	void Start () {

        if (!ballTarget)
        {
            Debug.Log("Attach a ball object reference to FollowBall script.");
            lookAtBall = false;
        }
        else
        {
            lookAtBall = true;
        }


	}
	
	// Update is called once per frame
	void Update ()
    {
        if(lookAtBall)
        {
            LookAtBall();
        }
		
	}

    public void LookAtBall()
    {
        Quaternion ballRot = Quaternion.LookRotation(ballTarget.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, ballRot.z, ballRot.w);
    }
}
