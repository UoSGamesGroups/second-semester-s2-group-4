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
    public GameObject redballFrags;
    public GameObject blueBallFrags;

//explosion animations in each goal
    public GameObject explosionRed;
    public GameObject explosionBlue;

    //Claw Script Reference
    GameObject clawControl;
    ClawScript clawScript;



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



        //get references to claw script
        clawControl = GameObject.Find("Claw");
        clawScript = clawControl.GetComponent<ClawScript>();

        

    }

    void Update()
    {

        


        //if the score popup is active
        if (scoreActive)
        {         
            //use a timer
            tempTimer -= Time.deltaTime;            
            if (tempTimer <= 0.0f)
            {
                blueBallFrags.SetActive(false);
                redballFrags.SetActive(false);
                //if timer less than or equal to 0
                //Set all gameobjects to inactive
                redScoreObject.SetActive(false);
                blueScoreObject.SetActive(false);
                //set scoreActive to false to break the loop
                scoreActive = false;
                explosionBlue.SetActive(false);
                explosionRed.SetActive(false);


                tempTimer = 1f;
            }
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
                GoalControllerScript.waveSpeed -= 1;
                GoalControllerScript.sliderScore += 1f / (GoalControllerScript.maxGoals * 2f);
                GoalControllerScript.scoreChange = true; //(GoalControllerScript.maxGoals * 2)

                //scale border colour
                //blueCol.transform.localScale -= new Vector3(0.1f, 0, 0);

                audioS.Play();
                

                redScoreObject.SetActive(true);
                scoreActive = true;
                

                //set ball Exploding to be true
                explosionRed.SetActive(true);

                //get animationt component of ballFrags


                //playing explosion animation
                explosionRed.GetComponent<Animator>().SetTrigger("explode");

                redballFrags.SetActive(true);
                redballFrags.GetComponent<Animation>().Play("ball_parts_explode");

                Debug.Log("Red Goal!");
            }

            if (!isRedGoal)
            {
                clawScript.dropClaw = true;

                GoalControllerScript.blueScore += 1;
                GoalControllerScript.waveSpeed += 1;
                GoalControllerScript.sliderScore -= 1f / (GoalControllerScript.maxGoals * 2f);
                GoalControllerScript.scoreChange = true;

                //scale border colour
                //blueCol.transform.localScale += new Vector3(0.1f, 0, 0);

                audioS.Play();

                
                blueScoreObject.SetActive(true);
                scoreActive = true;
              
                explosionBlue.SetActive(true);

                //get animationt component of ballFrags


                explosionBlue.GetComponent<Animator>().SetTrigger("explode");
                Debug.Log("Blue Goal!");

                 blueBallFrags.SetActive(true);
                blueBallFrags.GetComponent<Animation>().Play("ball_parts_explode");
               // blueBallFrags.PlayAnimation("ball_parts_explode")
               
            }
            
            GoalControllerScript.Reset();

        }
        
    }


}