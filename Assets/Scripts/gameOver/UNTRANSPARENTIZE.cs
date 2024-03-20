using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNTRANSPARENTIZE : MonoBehaviour
{
    float transparency;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        transparency = 0;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transparency<1)
        {
            renderer.color = new Color(1f, 1f, 1f, transparency);
            transparency += 0.01f;
        }
            
    }
}
