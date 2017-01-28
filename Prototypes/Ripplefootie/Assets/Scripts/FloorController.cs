using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour {

    // change this value to increase the number if floor tiles
   public int NumFloorTiles = 280;

    //Distance between prefabs (should be teh same at the scale of the prefab)
    public float Seperation = 0.05f;

    //Number of objects that get moved at once
    public int Grouping = 6;

    public GameObject FloorPrefab;
    public GameObject FloorControllerParent;

    // Use this for initialization
    void Start ()
    {
        

        for (int i = 0; i < NumFloorTiles; i++)
        {
                      
            GameObject Floor = Instantiate(FloorPrefab, new Vector3((i* Seperation + transform.position.x), -1, 0), Quaternion.identity) as GameObject;

            Floor.transform.parent = FloorControllerParent.transform;

            MovementControl AngleController = Floor.GetComponent<MovementControl>();
            AngleController.Angle = i / Grouping;
            AngleController.Y = transform.position.y;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
