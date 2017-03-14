using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetection : MonoBehaviour
{

    public bool isRedGoal;
    GameObject GoalControl;
    GoalController GoalControllerScript;


    //variables for visual indicator
    //that a goal is scored

    public GameObject fireworksRed01;
    public GameObject fireworksRed02;
    public GameObject fireworksBlue01;
    public GameObject fireworksBlue02;

    public GameObject redScoreObject;
    public GameObject blueScoreObject;

    void Start()
    {
        GoalControl = GameObject.Find("Arena");
        GoalControllerScript = GoalControl.GetComponent<GoalController>();

        //Set all gameobjects to inactive
        fireworksBlue01.SetActive(false);
        fireworksBlue02.SetActive(false);
        fireworksRed01.SetActive(false);
        fireworksRed02.SetActive(false);
        redScoreObject.SetActive(false);
        blueScoreObject.SetActive(false);
    }

    //Detect when a ball enters the goal
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            //Decision on which goal to add points to
            if (isRedGoal)
            {
                GoalControllerScript.redScore += 1;
                GoalControllerScript.sliderScore++;
                GoalControllerScript.scoreChange = true;

               // fireworksRed01.SetActive(true);
                fireworksRed02.SetActive(true);
                redScoreObject.SetActive(true);


                Debug.Log("Red Goal!");
            }
            if (!isRedGoal)
            {
                GoalControllerScript.blueScore += 1;
                GoalControllerScript.sliderScore--;
                GoalControllerScript.scoreChange = true;

               // fireworksBlue01.SetActive(true);
                fireworksBlue02.SetActive(true);
                blueScoreObject.SetActive(true);

                Debug.Log("Blue Goal!");

            }
            //Set all gameobjects to inactive
            fireworksBlue01.SetActive(false);
            fireworksBlue02.SetActive(false);
            fireworksRed01.SetActive(false);
            fireworksRed02.SetActive(false);
            redScoreObject.SetActive(false);
            blueScoreObject.SetActive(false);

            GoalControllerScript.Reset();



        }
    }


}