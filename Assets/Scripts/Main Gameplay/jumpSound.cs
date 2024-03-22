using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpSound : MonoBehaviour
{
    AudioSource myAudio;
    bool beenPlayed;
    public bool auto;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3.0f;
        myAudio = GetComponent<AudioSource>();
        beenPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Jump") ==1)
        {
            if(transform.position.x >5.0f && transform.position.y < -1.5f)
            {
                if (!beenPlayed)
                {
                    myAudio.Play();
                    beenPlayed = true;

                    
                }
                
            }
        }

        if(Input.GetAxis("Jump")== 0)
        {
            beenPlayed = false;
        }

        if(auto)
        {
            if(timer<=0)
            {
                if (transform.position.x > 5.0f && transform.position.y < -1.5f)
                {
                    if (!beenPlayed)
                    {
                        myAudio.Play();
                        beenPlayed = true;


                    }

                }
                timer = 3.0f;
            }
            else if(transform.position.x > 5.0f && transform.position.y < -1.5f)
            {
                timer -= Time.deltaTime;

            }
        }
    }
}
