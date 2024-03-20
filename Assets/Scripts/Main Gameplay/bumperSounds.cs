using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumperSounds : MonoBehaviour
{

    AudioSource myAudio;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject.CompareTag("1Pointer"))
        {
            myAudio.Play();
        }
        if (otherObject.gameObject.CompareTag("5Pointer"))
        {
            myAudio.Play();
        }
        if (otherObject.gameObject.CompareTag("10Pointer"))
        {
            myAudio.Play();
        }
        if (otherObject.gameObject.CompareTag("20Pointer"))
        {
            myAudio.Play();
        }
        if (otherObject.gameObject.CompareTag("50Pointer"))
        {
            myAudio.Play();
        }
    }
}
