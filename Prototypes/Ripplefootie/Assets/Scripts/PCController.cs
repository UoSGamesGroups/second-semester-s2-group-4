﻿using UnityEngine;
using System.Collections;

//For character movement, keys are (ideally) rebindable, so only one script is needed
//isGrounded code: http://answers.unity3d.com/questions/149790/checking-if-grounded-on-rigidbody.html

public class PCController : MonoBehaviour
{
    public KeyCode kcRight = KeyCode.RightArrow;
    public KeyCode kcLeft = KeyCode.LeftArrow;
    public KeyCode kcUp = KeyCode.UpArrow;
    public KeyCode kcDown = KeyCode.DownArrow;
    public KeyCode kcKick = KeyCode.Space;
    public float KickSpeed = 10;

    //The amount of force applied per frame to the rigidbody
    public float moveSpeed;
    //The amount of force applied on a jump
    public float jumpSpeed;
    //A bool to check if the player is currently grounded
    public bool isGrounded = false;
    private Rigidbody2D RigidB;

    //audio source
    AudioSource audioS;

    // Use this for initialization
    void Start()
    {
        RigidB = GetComponent<Rigidbody2D>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float unmodifiedMoveSpeed = moveSpeed;
        //Move Right
        if (Input.GetKey(kcRight))
        {
            RigidB.AddForce(new Vector2(moveSpeed, 0), ForceMode2D.Force);

        }
        //Move Left
        if (Input.GetKey(kcLeft))
        {
            RigidB.AddForce(new Vector2(-moveSpeed, 0), ForceMode2D.Force);
        }
        //Jump
        if (Input.GetKey(kcUp) && isGrounded == true)
        {
            isGrounded = false;
            //Debug.Log("Should be jumping");
            RigidB.AddForce(new Vector2(0, jumpSpeed)/*, ForceMode2D.Impulse*/);
            //GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            audioS.Play();
        }
        //force downward
        if (Input.GetKeyDown(kcDown)&&isGrounded == false)
        {
            RigidB.AddForce(new Vector2(0, -jumpSpeed/2));
        }

    }

    void OnCollisionStay2D(Collision2D Collider)
    {
        if (Collider.gameObject.tag == "gROUND")
        {
            isGrounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D Collider)
    {
        if (Collider.gameObject.tag == "gROUND")
        {
            isGrounded = false;
        }
    }

    void OnTriggerStay2D(Collider2D Collider)
    {
        //Kick
        if (Input.GetKeyDown(kcKick) && Collider.gameObject.tag == "Ball")
        {
            Rigidbody2D BallRB = Collider.gameObject.GetComponent<Rigidbody2D>();
            Vector2 BallForce = Collider.gameObject.transform.position - this.transform.position;// ball -player
            float Magnitude = Mathf.Sqrt(Mathf.Pow(BallForce.x, 2) + Mathf.Pow(BallForce.y, 2));


            BallRB.AddForce(new Vector2(KickSpeed * BallForce.x / Magnitude, KickSpeed * BallForce.y / Magnitude));
        }
    }
}
