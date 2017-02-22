using System.Collections;
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

    public GameObject ball;
    public GameObject player1;
    public GameObject player2;

    public int timeTracker;

    public bool scoreChange = false;

    public Slider scoreSlider;


    Vector3 ballOriginPos;
    Vector3 player1OriginPos;
    Vector3 player2OriginPos;


    // Use this for initialization
    void Start ()
    {
        //sets the original vector points, happens at the beginning of the game (you can move the ball and players around to whereever and they will just teleport back there)
        ballOriginPos = ball.transform.position;
        player1OriginPos = player1.transform.position;
        player2OriginPos = player2.transform.position;

        //Starts the timer Coroutine
        StartCoroutine(Timer());

    }
	
	// Update is called once per frame
	void Update ()
    {

        scoreSlider.value = sliderScore;
        if (scoreChange)
        {
            resetBall();
        }
        if (scoreSlider.value == scoreSlider.minValue)
        {
            Debug.Log("Blue Wins");
        }

        if (scoreSlider.value == scoreSlider.maxValue)
        {
            Debug.Log("Red Wins");
        }

        //if (Input.GetButtonDown("Jump"))
        //{
        //    scoreChange = true;
        //    redScore += 1;
        //}

	}

    void resetBall()
    {
        ball.transform.position = ballOriginPos;
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        scoreChange = false;
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
