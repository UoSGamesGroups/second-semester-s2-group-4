using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to control the movement/jumping of the characters and the "kicking" mechanic

public class CharacterController : MonoBehaviour
{

    //Bool to tell if the player is faceing right or left
    private bool facingRight = false;
    //Maximum speed the player can travel in the X axis
    private float maxHorizontalSpeed = 10f;
    //The amount of force added when the player jumps
    public float jumpForce = 100f;
    //Bool to determine if the player is red or not
    public bool redPlayer;
    //A position marking where to check if the player is grounded 
    private Transform groundCheck;
    //Bool to keep track of if the player is grounded
    private bool grounded;







	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
