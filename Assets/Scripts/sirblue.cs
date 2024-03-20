using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sirblue : MonoBehaviour
{
    float transparency;
    int direction;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        transparency = 0;
        direction = 1;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transparency < 1 && direction == 1)
        {
            renderer.color = new Color(1f, 1f, 1f, transparency);
            transparency += 0.01f * direction;
            if (transparency >= 1)
            {
                direction = -1;
            }
        }
        if (transparency > 0 && direction == -1)
        {
            renderer.color = new Color(1f, 1f, 1f, transparency);
            transparency += 0.05f * direction;
            if (transparency <= 0)
            {
                direction = 1;
            }
        }


    }
}
