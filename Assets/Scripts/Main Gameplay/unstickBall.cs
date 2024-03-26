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
        if (transform.position.x < -4.9885)
        {
            transform.position = transform.position + new Vector3(transform.position.x * -1 + 1, transform.position.y, 0);
        }
        if (transform.position.x > 8.630001)
        {
            transform.position = transform.position + new Vector3(transform.position.x * -1 - 1, transform.position.y, 0);
        }
        //timer 
        if (stuck)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else if (timer <= 0)
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
                
                if (transform.position.y >= 10.58f)
                {
                    transform.position = transform.position + new Vector3(0, -2.0f, 0);
                }
                else
                {
                    transform.position = transform.position + new Vector3(0, 1.5f, 0);
                }
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
