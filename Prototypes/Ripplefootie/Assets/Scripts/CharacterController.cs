using UnityEngine;
using System.Collections;

//For character movement, keys are (ideally)rebindable, so only one script is needed
//isGrounded code: http://answers.unity3d.com/questions/149790/checking-if-grounded-on-rigidbody.html

public class CharacterController : MonoBehaviour
{
    public KeyCode kcRight = KeyCode.RightArrow;
    public KeyCode kcLeft = KeyCode.LeftArrow;
    public KeyCode kcUp = KeyCode.UpArrow;

    //The amount of force applied per frame to the rigidbody
    public float moveSpeed;
    //The amount of force applied on a jump
    public float jumpSpeed;
    //A bool to check if the player is currently grounded
    bool isGrounded = false;
    private Rigidbody2D RigidB;

    // Use this for initialization
    void Start()
    {
        RigidB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
        if (Input.GetKeyDown(kcUp))
        {
            Debug.Log("Should be jumping");
            RigidB.velocity = new Vector2(0, jumpSpeed);
        }



    }
    void OnCollisionStay(Collision collisionInfo)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        isGrounded = false;
    }

}
