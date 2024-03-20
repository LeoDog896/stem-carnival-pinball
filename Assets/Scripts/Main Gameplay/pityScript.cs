using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pityScript : MonoBehaviour
{
    float transparency;
    SpriteRenderer renderer;
    bool timeToGo;

    // Start is called before the first frame update
    void Start()
    {
        transparency = 1;
        renderer = GetComponent<SpriteRenderer>();
        timeToGo = false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (transparency > 0 && timeToGo)
        {
            renderer.color = new Color(1f, 1f, 1f, transparency);
            transparency -= 0.02f;
            if (transparency <= 0)
            {
                Destroy(this);
            }
        }
        if(Input.GetAxis("Jump")==1)
        {
            timeToGo = true;
        }
    }
}
