using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class P1Input : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool _jump = false;
    public float moveSpeed = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;



    [SerializeField]
    private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;
   // private Animator anim;
    private Rigidbody2D rb;


    // Use this for initialization
    void Awake()
    {
       // anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        m_GroundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
       // anim.SetBool("Ground", m_Grounded);


        

    }

    void FixedUpdate()
    {




        float h = Input.GetAxis("Horizontal");


       // anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb.velocity.x < maxSpeed)
            rb.AddForce(Vector2.right * h * moveSpeed);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();


        //Jump
        if (Input.GetKey(KeyCode.W) && m_Grounded) //&& anim.GetBool("Ground"))
        {
            m_Grounded = false;
           // anim.SetBool("Ground", false);
            Jump();
        }


    }

    public void Jump()  // Enables you to write Jump(); instead of code below to make code look neater and shorter
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
