using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eddieScript : MonoBehaviour
{
    float timer;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        timer = 26.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer<=0)
        {
            music.Play();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
