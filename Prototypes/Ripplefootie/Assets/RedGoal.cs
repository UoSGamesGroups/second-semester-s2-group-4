using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedGoal : MonoBehaviour {

    public int redScore = 5;
    public int currentRedScore;
    public bool scoreChange = false;

    public int blueScore = 0;
    public int currentBlueScore;
    public Slider scoreSlider;
    
    
    // Use this for initialization
	void Start () {
        scoreSlider.value = redScore;
        currentRedScore = redScore;
        currentBlueScore = blueScore;
	}
	
	// Update is called once per frame
	void Update ()
    {



    if(scoreChange)
        {
            scoreChange = false;
            if (currentRedScore <= redScore)
            {
                currentRedScore = redScore;
                ResetSlider();
            }

            
            if (currentBlueScore <= blueScore)
            {
                currentBlueScore = blueScore;
                currentRedScore = currentRedScore - currentBlueScore;
                ResetSlider();
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            scoreChange = true;
            redScore += 1;
        }

	}

    void OnCollision2DEnter(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
           
            redScore += 1;
            scoreChange = true;
            ResetSlider();
        }
    }

   public void ResetSlider()
    {
        scoreSlider.value = currentRedScore;
        if (scoreSlider.value == scoreSlider.minValue)
        {           

            Debug.Log("Blue Wins");
        }
        if (scoreSlider.value == scoreSlider.maxValue)
        {
            Debug.Log("Red Wins");
        }

    }
}
