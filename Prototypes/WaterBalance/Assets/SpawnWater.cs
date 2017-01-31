using UnityEngine;
using System.Collections;

public class SpawnWater : MonoBehaviour {

    public GameObject Water;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
            Instantiate(Water, new Vector3(0,1,1), Quaternion.identity);
	}
}
