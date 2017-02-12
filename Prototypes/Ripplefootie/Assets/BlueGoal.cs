using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGoal : MonoBehaviour
{

    RedGoal redGoalScript;



    void Start()
    {
        redGoalScript = FindObjectOfType<RedGoal>();
        redGoalScript.GetComponent<RedGoal>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.B))
        {
            redGoalScript.blueScore += 1;
            redGoalScript.scoreChange = true;
        }

    }

    void OnCollision2DEnter(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            redGoalScript.blueScore += 1;
            redGoalScript.scoreChange = true;

        }
    }

}
