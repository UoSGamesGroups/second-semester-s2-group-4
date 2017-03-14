using UnityEngine;
using System.Collections;

//For character movement, keys are (ideally)rebindable, so only one script is needed
//isGrounded code: http://answers.unity3d.com/questions/149790/checking-if-grounded-on-rigidbody.html

public class PCController : MonoBehaviour
{
    public KeyCode kcRight = KeyCode.RightArrow;
    public KeyCode kcLeft = KeyCode.LeftArrow;
    public KeyCode kcUp = KeyCode.UpArrow;

    //The amount of force applied per frame to the rigidbody
    public float moveSpeed;
    //The amount of force applied on a jump
    public float jumpSpeed;
    //A bool to check if the player is currently grounded
    public bool isGrounded = false;
    private Rigidbody2D RigidB;

    // Use this for initialization
    void Start()
    {
        RigidB = GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(kcUp) && isGrounded == true)
        {
            Debug.Log("Should be jumping");
            RigidB.AddForce(new Vector2(0, jumpSpeed)/*, ForceMode2D.Impulse*/);
            //GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }



    void OnCollisionEnter2D(Collision2D Collider)
    {
        //If the there is a collider and its not the ball, and isGrounded isn't already true
        if (Collider.collider == true && Collider.gameObject.tag != "Ball" && isGrounded != true)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D Collider)
    {
        if (Collider.collider == true && Collider.gameObject.tag != "Ball")
        {
            isGrounded = false;
        }
    }
}
