using UnityEngine;
using System.Collections;
public class MovementControl : MonoBehaviour {
    public float Angle;
    public float Y;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, Y + Mathf.Sin(Angle)*0.2f, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, Y + Mathf.Sin(Angle) * 0.2f, transform.position.z);
        Angle += 0.1f;

    }


}
