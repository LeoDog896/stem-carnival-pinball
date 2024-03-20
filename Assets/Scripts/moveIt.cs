using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveIt : MonoBehaviour
{
    //6 seconds
    float timer, timer2;

    // Start is called before the first frame update
    void Start()
    {
        timer = 6.0f;
        timer2 = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            gameObject.transform.Translate(-15 * Time.deltaTime, 0, 0);
            timer2 -= Time.deltaTime;
            if(timer2<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
