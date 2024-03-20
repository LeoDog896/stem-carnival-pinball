using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flippersounds : MonoBehaviour
{
    AudioSource myAudio;
    bool left, right;
    public AudioClip flip;
    // Start is called before the first frame update
    void Start()
    {
        left = true;
        right = true;
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = flip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && left)
        {
            myAudio.Play();
            left = false;
        }
        else if (!Input.GetKey(KeyCode.F))
        {
            left = true;
        }



        if (Input.GetKey(KeyCode.J) && right)
        {
            myAudio.Play();
            right = false;
        }
        else if (!Input.GetKey(KeyCode.J))
        {
            right = true;
        }

    }
}
