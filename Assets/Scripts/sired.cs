using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sired : MonoBehaviour
{
    float transparency, startTimer;
    SpriteRenderer renderer;
    int direction;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = 1.0f;
        transparency = 0;
        direction = 1;
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1f, 1f, 1f, transparency);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(startTimer<=0)
        {
            if (transparency < 1 && direction == 1)
            {
                renderer.color = new Color(1f, 1f, 1f, transparency);
                transparency += 0.01f*direction;
                if(transparency>=1)
                {
                    direction = -1;
                }
            }
            if (transparency >0 && direction == -1)
            {
                renderer.color = new Color(1f, 1f, 1f, transparency);
                transparency += 0.05f * direction;
                if(transparency<=0)
                {
                    direction = 1;
                }
            }
        }
        else
        {
            startTimer -= Time.deltaTime;
        }
        

    }
}
