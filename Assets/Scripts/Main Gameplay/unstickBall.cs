using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unstickBall : MonoBehaviour
{
    float timer;
    bool stuck, isStuck;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5.0f;
        isStuck = false;
        stuck = false;
    }

    // Update is called once per frame
    void Update()
    {
        //timer 
        if(stuck)
        {
            if(timer>0)
            {
                timer -= Time.deltaTime;
            }
            else if(timer<=0)
            {
                isStuck = true;
                
            }
        }


        if (isStuck)
        {
            //Debug.Log("Player might be stuck");
            stuck = false;
            timer = 5.0f;
            if (Input.GetAxis("Jump") == 1 && isStuck)
            {
                transform.position = transform.position + new Vector3(0, 1.5f, 0);
                isStuck = false;
            }
        }

    }


    void OnCollisionEnter2D(Collision2D otherObject)
    {
        stuck = true;
    }

    void OnCollisionExit2D(Collision2D otherObject)
    {
        stuck = false;
        isStuck = false;
        timer = 5.0f;
    }
}
