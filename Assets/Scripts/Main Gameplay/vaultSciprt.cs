using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vaultSciprt : MonoBehaviour
{
    //sound
    bool vaultTouched;

    //Animator
    Animator notMyAnim;

    AudioSource myAudio;
    public AudioClip metal1, metal2;

    //Controls the stage
    public int health, wallNum;
    float timer, icktimer, timerTimer;
    public GameObject wall1Prefab, wall2Prefab;
    int stickCount, stoneCount;


    // Start is called before the first frame update
    void Start()
    {
        
        myAudio = GetComponent<AudioSource>();
       stickCount = -400;
        stoneCount = -400;
        timer = 0.5f;
        icktimer = timer;
        timerTimer = timer;
        //Set health value
        health = 9;
        //Steal the Animator component
        notMyAnim = GetComponent<Animator>();

    }

    void Update()
    {
        if ((icktimer <= 0) && (stickCount>=0))
        { 
            Instantiate(wall1Prefab);
            stickCount--;
            icktimer = timerTimer;
        }
        else if((stickCount>=0) && (icktimer>=0))
        { 
            icktimer -= Time.deltaTime;
        }

        if ((timer <= 0) && (stoneCount >= 0))
        {
            
            Instantiate(wall2Prefab);
            stoneCount--;
            timer = timerTimer;
        }
        else if ((stoneCount >= 0) && (timer >= 0))
        {
            timer -= Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        

        if(otherObject.gameObject.CompareTag("Player"))
        {
            health--;
            Debug.Log("OH NO! DAMAGE! MY WEAKNESSS!!!");
            Debug.Log("Mental Health Update: " + health);

            if((int)Random.Range(0,2) ==0)
            {

                myAudio.clip = metal2;
            }
            else
            {

                myAudio.clip = metal1;
            }
            myAudio.Play();

            if(health >=7)
            {
                //Base stage (Basic asset, no wall)
                notMyAnim.SetInteger("damage", 1);

            }
            else if(health>=5)
            {
                notMyAnim.SetInteger("damage", 2);
            }
            else if(health>= 4)
            {
                notMyAnim.SetInteger("damage", 3);

                //Damaged State (Add wall)
                Debug.Log("YOU FOOL, YOU TRIPPED THE ALARM!");
                VaultWalls();
            }
            else if(health>=2)
            {
                notMyAnim.SetInteger("damage", 4);
                VaultWalls();

            }
            else if(health<=0)
            {
                Debug.Log("Something went wrong, this isn't supposed to happen");
                notMyAnim.SetInteger("damage", 5);
                Invoke("endGame", 3.0f);
            }

        }
    }

    void VaultWalls()
    {
        Debug.Log("wall");
        if (health >= 4)
        {
            stickCount = 30;
        }
        else if (health >=3)
        {
            stoneCount = 30;
        }
        else if (health >=2)
        {
            stickCount = 40;
            stoneCount = 50;
        }
        else if(health<=1)
        {
            stickCount = 50;
            stoneCount = 60;
        }
    }

    void endGame()
    {
        //SceneManager.LoadScene("VaultLeaderboard");
        if (SceneManager.GetActiveScene().name.Equals("MainGameplay"))
        {
            SceneManager.LoadScene("ScoreScene2");
        }
        else if (SceneManager.GetActiveScene().name.Equals("preview"))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
