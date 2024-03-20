using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pepTalk : MonoBehaviour
{
    public AudioClip line1, line2, line3;
    public AudioSource eddie;
    int num;
    float timer;
    bool played;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1.0f;
        played = false;
        num = (int)Random.Range(0, 3);
        if(num==0)
        {
            eddie.clip = line1;
        }
        else if(num == 1)
        {
            eddie.clip = line2;
        }
        else if(num==2)
        {
            eddie.clip = line3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<=0)
        {
            if(!played)
            {
                eddie.Play();
                played = true;
            }
        }
        timer -= Time.deltaTime;
    }
}
