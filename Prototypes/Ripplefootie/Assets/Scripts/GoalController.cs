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

    public int waveSpeed;

    public GameObject ball, player1, player2;
    public int maxGoals = 4; // The number of goals needed to win

    public int timeTracker;

    public bool scoreChange = false;

    Vector3 ballOriginPos;

    GameObject waveController;
    TestRipple2 waveControllerScript;

    //Declare all ball objects
    public GameObject redBall1, redBall2, redBall3, redBall4;
    public GameObject blueBall1, blueBall2, blueBall3, blueBall4;
    //public GameObject redTextObj, blueTextObj;
    public Text redText, blueText;

    //reference to main menu script
    //to affect shown image on Game Over screen.
    GameObject mainMenu;
    MainMenu menuScript;



    // Use this for initialization
    void Start ()
    {
        //sets the original vector points, happens at the beginning of the game (you can move the ball and players around to whereever and they will just teleport back there)
        ballOriginPos = ball.transform.position;

        //Starts the timer Coroutine
        StartCoroutine(Timer());

        waveController = GameObject.Find("WaveOrigin");
        waveControllerScript = waveController.GetComponent<TestRipple2>();

        mainMenu = GameObject.Find("MenuObject");
        menuScript = mainMenu.GetComponent<MainMenu>();

        //redText = redTextObj.GetComponent <Text>();
        
    }

    void Awake()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (waveSpeed == 0)
        {
            int beginning = Random.Range(0, 2);
            if (beginning == 1)
                waveSpeed = 1;
            else
                waveSpeed = -1;
            scoreChange = true;
        }

        if (scoreChange)
        {
            //Debug.Log("Resetting Ball");
            resetBall();
            //Debug.Log("Ball Reset, changing wave...");
            changeWave();
            //Debug.Log("Wave Changed");
            scoreChange = false;
            //Run score changer
            GoalChange();
        }
	}

    void resetBall()
    {
        Debug.Log("Resetting Ball");
        ball.transform.position = ballOriginPos;
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);  
    }

    void changeWave()
    {
        //Blue Advantage
        if (waveSpeed > 0)
            waveControllerScript.angleIncrement = waveSpeed / 100f;
        //Red advantage
        if (waveSpeed < 0)
            waveControllerScript.angleIncrement = waveSpeed / 100f;
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            timeTracker++;
        }

    }

    void GoalChange()
    {
        redText.text = blueScore.ToString();
        blueText.text = redScore.ToString();
        if (redScore == 1)
        {
            redBall1.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }
        if (redScore == 2)
        {
            redBall2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }
        if (redScore == 3)
        {
            redBall3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }
        if (redScore == 4)
        {
            redBall4.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }

        if (blueScore == 1)
        {
            blueBall1.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }
        if (blueScore == 2)
        {
            blueBall2.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }
        if (blueScore == 3)
        {
            blueBall3.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }
        if (blueScore == 4)
        {
            blueBall4.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }
    }
}
