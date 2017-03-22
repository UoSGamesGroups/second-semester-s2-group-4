using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetection : MonoBehaviour
{

    public bool isRedGoal;
    GameObject GoalControl;
    GoalController GoalControllerScript;

    public float tempTimer = 1f;

    //variables for visual indicator
    //that a goal is scored

    public GameObject redScoreObject;
    public GameObject blueScoreObject;
    private bool scoreActive = false;

    //Ball fragments (for ball explosion when a goal is scored)
    //array of gameobjects for red goal
    public GameObject[] redfragmant;
    public bool ballExploding = false;
    public GameObject explosionRed;

    //array of objects for blue goal
    public GameObject[] blueFragment;
    public bool blueballExploding = false;
    public GameObject explosionBlue;

    //Claw Script Reference
    GameObject clawControl;
    ClawScript clawScript;

    //reference to border scaling colours
    public GameObject redCol;
    public GameObject blueCol;

    //audio source
    AudioSource audioS;

    void Start()
    {
        GoalControl = GameObject.Find("Arena");
        GoalControllerScript = GoalControl.GetComponent<GoalController>();

        audioS = GetComponent<AudioSource>();


        //Set all gameobjects to inactive
        redScoreObject.SetActive(false);
        blueScoreObject.SetActive(false);

        //assign objects with tag "ball" to the array
       redfragmant = GameObject.FindGameObjectsWithTag("ball");
        blueFragment = GameObject.FindGameObjectsWithTag("blueBall");

        //get references to claw script
        clawControl = GameObject.Find("Claw");
        clawScript = clawControl.GetComponent<ClawScript>();

        //Debug.Log(fragmant.Length);
    }

    void Update()
    {

        if (ballExploding)
        {
            
            //for each object in fragmant array            
            
            foreach (GameObject i in redfragmant)
            {
                //get the rigidbody component
                //activate objects
                i.SetActive(true);
                
                //choose a random direction for each piece to move in
                Vector2 randomDir = new Vector2(Random.Range(1,100), Random.Range(1,100));
                //add force, in the forward direction * 100 force
                 i.GetComponent<Rigidbody2D>().AddForce(randomDir * 100);

                i.GetComponent<Rigidbody2D>().AddTorque(90);

            }
        }

        if (blueballExploding)
        {
            //for each object in fragmant array            

            foreach (GameObject i in blueFragment)
            {
                //get the rigidbody component
                //activate objects
                i.SetActive(true);
                //choose a random direction for each piece to move in
                Vector2 randomDir = new Vector2(Random.Range(1, 100), Random.Range(1, 100));
                //add force, in the forward direction * 100 force
                i.GetComponent<Rigidbody2D>().AddForce(randomDir * 100);
                i.GetComponent<Rigidbody2D>().AddTorque(90);
            }
        }
        //if the score popup is active
        if (scoreActive)
        {         
            //use a timer
            tempTimer -= Time.deltaTime;            
            if (tempTimer <= 0.0f)
            {
                //if timer less than or equal to 0
                //Set all gameobjects to inactive
                redScoreObject.SetActive(false);
                blueScoreObject.SetActive(false);
                //set scoreActive to false to break the loop
                scoreActive = false;
                explosionBlue.SetActive(false);
                explosionRed.SetActive(false);

                blueballExploding = false;
                ballExploding = false;
                tempTimer = 1f;
            }
        }
        //disable all ball fragmant objects
        foreach (GameObject x in blueFragment)
        {
            x.SetActive(false);
        }

        ballExploding = false;
        foreach (GameObject x in redfragmant)
        {
            x.SetActive(false);
        }
    }

   



    //Detect when a ball enters the goal
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            
            //Decision on which goal to add points to
            if (isRedGoal)
            {
                clawScript.dropClaw = true;
                GoalControllerScript.redScore += 1;
                GoalControllerScript.sliderScore -= 1 / 6;
                GoalControllerScript.scoreChange = true; //(GoalControllerScript.maxGoals * 2)

                //scale border colour
                //blueCol.transform.localScale -= new Vector3(0.1f, 0, 0);

                audioS.Play();

                redScoreObject.SetActive(true);
                scoreActive = true;
                

                //set ball Exploding to be true
                ballExploding = true;
                explosionRed.SetActive(true);            

                //playing explosion animation
                explosionRed.GetComponent<Animator>().SetTrigger("explode");
                //set bool true to explode ball pieces
                ballExploding = true;
               
                Debug.Log("Red Goal!");
            }

            if (!isRedGoal)
            {
                clawScript.dropClaw = true;

                GoalControllerScript.blueScore += 1;
                GoalControllerScript.sliderScore = GoalControllerScript.sliderScore - (1 / 6);
                GoalControllerScript.scoreChange = true;

                //scale border colour
                //blueCol.transform.localScale += new Vector3(0.1f, 0, 0);

                audioS.Play();

                
                blueScoreObject.SetActive(true);
                scoreActive = true;
                blueballExploding = true;
                explosionBlue.SetActive(true);
                
                explosionBlue.GetComponent<Animator>().SetTrigger("explode");
                Debug.Log("Blue Goal!");

                //set bool true to explode ball pieces
                blueballExploding = true;
               
            }
            
            GoalControllerScript.Reset();
            
        }
        
    }


}