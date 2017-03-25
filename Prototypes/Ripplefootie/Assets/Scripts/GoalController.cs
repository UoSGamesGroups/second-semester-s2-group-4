﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour {

    //Score holders

    //Holds the number of goals the red player has
    public int redScore = 0;
    //Holds the number of goals the blue player has
    public int blueScore = 0;
    //Holds the number of goals represented on the slider bar
    public float sliderScore;
    public float supposedSliderscore;


    public GameObject ball;
    public GameObject player1;
    public GameObject player2;

    public Image blueBar;//The blue part of the background
    public int maxGoals; // The number of goals needed to win

    public int timeTracker;

    public bool scoreChange = false;

    Vector3 ballOriginPos;
    Vector3 player1OriginPos;
    Vector3 player2OriginPos;

    GameObject waveController;
    TestRipple2 waveControllerScript;

    //reference to main menu script
    //to affect shown image on Game Over screen.
    GameObject mainMenu;
    MainMenu menuScript;



    // Use this for initialization
    void Start ()
    {
        //sets the original vector points, happens at the beginning of the game (you can move the ball and players around to whereever and they will just teleport back there)
        ballOriginPos = ball.transform.position;
        player1OriginPos = player1.transform.position;
        player2OriginPos = player2.transform.position;

        //Starts the timer Coroutine
        StartCoroutine(Timer());

        waveController = GameObject.Find("WaveOrigin");
        waveControllerScript = waveController.GetComponent<TestRipple2>();

        mainMenu = GameObject.Find("MenuObject");
        menuScript = mainMenu.GetComponent<MainMenu>();


    }
	
	// Update is called once per frame
	void Update ()
    {
        ////Smooth movement on the fill
        //if (blueBar.fillAmount != supposedSliderscore)
        //{
        //    //If its closer to the blue side
        //    if (blueBar.fillAmount < supposedSliderscore && blueBar.fillAmount < 0.5f)
        //    {
        //        blueBar.fillAmount += 0.01f;
        //    }
        //    //If its closer to the blue side
        //    else if (blueBar.fillAmount > supposedSliderscore && blueBar.fillAmount > 0.5f)
        //    {
        //        blueBar.fillAmount -= 0.01f;
        //    }
        //}

        blueBar.fillAmount = sliderScore;

        if (scoreChange)
        {
            //Debug.Log("Resetting Ball");
            resetBall();
            //Debug.Log("Ball Reset, changing wave...");
            changeWave();
            //Debug.Log("Wave Changed");
            scoreChange = false;
        }

        if (blueBar.fillAmount <= 0)
        {
            Debug.Log("Blue Wins");
            menuScript.redWon = true;                    
            menuScript.LoadByIndex(2);
           
            
        }

        if (blueBar.fillAmount >= 1)
        {
            Debug.Log("Red Wins");
            menuScript.blueWon = true;         
            menuScript.LoadByIndex(3);

        }

        //if (Input.GetButtonDown("Jump"))
        //{
        //    scoreChange = true;
        //    redScore += 1;
        //}

	}

    void resetBall()
    {
        Debug.Log("Resetting Ball");
        ball.transform.position = ballOriginPos;
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);  



    }

    void changeWave()
    {

        if(sliderScore == 0.5)
        {
            waveControllerScript.angleIncrement = 0.0f;
        }
        //Blue Advantage
        if (sliderScore > 0.5)
        {
            waveControllerScript.angleIncrement = sliderScore / 100;
        }
        //Red advantage
        if (sliderScore < 0.5)
        {
            waveControllerScript.angleIncrement = -(sliderScore / 100);
        }

    }
    //Sets outofbounds objects back to their origin points
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player1")
        {
            player1.transform.position = player1OriginPos;
        }
        if (other.name == "Player2")
        {
            player2.transform.position = player2OriginPos;
        }
        if (other.name == "Ball")
        {
            ball.transform.position = ballOriginPos;
        }

    }

    public void Reset()
    {
       
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            timeTracker++;
        }

    }
}
