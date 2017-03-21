using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoundScript : MonoBehaviour {
    public AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider)
        {
            audioS.Play();
        }
    }
}
