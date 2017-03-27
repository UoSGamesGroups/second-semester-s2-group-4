using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpBack : MonoBehaviour {

    //sets the original vector points, happens at the beginning of the game
    //(you can move the ball and players around to where ever and they will just teleport back there)

    public GameObject warpObject;
    Vector3 startPos;
	// Use this for initialization
	void Start ()
    {
         startPos = warpObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Warp")
        {
            warpObject.transform.position = startPos;
        }
        
    }
}
