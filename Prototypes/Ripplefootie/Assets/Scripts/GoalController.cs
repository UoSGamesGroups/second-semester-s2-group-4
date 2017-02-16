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
    public int sliderScore;
    

    public bool scoreChange = false;

    public Slider scoreSlider;
    
    
    // Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

        scoreSlider.value = sliderScore;

        if (scoreSlider.value == scoreSlider.minValue)
        {
            Debug.Log("Blue Wins");
        }

        if (scoreSlider.value == scoreSlider.maxValue)
        {
            Debug.Log("Red Wins");
        }

        if (Input.GetButtonDown("Jump"))
        {
            scoreChange = true;
            redScore += 1;
        }

	}

    public void Reset()
    {

    }
}
