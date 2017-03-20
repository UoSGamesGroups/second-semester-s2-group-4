using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawScript : MonoBehaviour {



    public bool dropClaw = false;


    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dropClaw)
        {
            anim.SetTrigger("clawDrop");
            
            dropClaw = false;
        }
		
	}



}
