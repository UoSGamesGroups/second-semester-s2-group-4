using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour {

    public Vector3 originPos;
    public Quaternion originRot;

    public float shakeDecay;
    public float shakeIntensity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (shakeIntensity > 0)
        {
            transform.position = originPos + Random.insideUnitSphere * shakeIntensity;
            transform.rotation = new Quaternion(originRot.x + Random.Range(-shakeIntensity, shakeIntensity) * 0.02f,
                originRot.y + Random.Range(-shakeIntensity, shakeIntensity) * 0.02f,
                originRot.z + Random.Range(-shakeIntensity, shakeIntensity) * 0.02f,
                originRot.w + Random.Range(-shakeIntensity, shakeIntensity) * 0.02f);
            shakeIntensity -= shakeDecay;

            //setting the transform/rotation back to original.
            if (shakeIntensity <= 0)
            {
                transform.position = originPos;
                transform.rotation = originRot;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShakeCam();
        }
		
	}

    void ShakeCam()
    {
        originPos = transform.position;
        originRot = transform.rotation;
        //how much the camera shakes
        shakeIntensity = 0.1f;
        //how quickly it stops shaking
        shakeDecay = 0.002f;
    }
}
