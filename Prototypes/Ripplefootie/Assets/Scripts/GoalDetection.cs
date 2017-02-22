using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetection : MonoBehaviour
{

    public bool isRedGoal;
    GameObject GoalControl;
    GoalController GoalControllerScript;

    void Start()
    {
        GoalControl = GameObject.Find("Arena");
        GoalControllerScript = GoalControl.GetComponent<GoalController>();

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
                Debug.Log("Red Goal!");
            }
            if (!isRedGoal)
            {
                GoalControllerScript.blueScore += 1;
                GoalControllerScript.sliderScore--;
                GoalControllerScript.scoreChange = true;
                Debug.Log("Blue Goal!");

            }
            GoalControllerScript.Reset();
        }
    }
}