using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vanish : MonoBehaviour
{

    //This code is incomplete because I never found a use for it. 
    float transparency;
    SpriteRenderer renderer;

  
    // Start is called before the first frame update
    void Start()
    {
        transparency = 1;
        renderer = GetComponent<SpriteRenderer>();
    }


        void FixedUpdate()
    {
        if (Input.GetAxis("Jump") == 1)
        {
            Debug.Log("Skip");
            Function();
        }
        
        if (transparency > 0)
        {
            renderer.color = new Color(1f, 1f, 1f, transparency);
            transparency -= 0.01f;
            if(transparency<=0)
            {
                Invoke("Function", 5.0f);
            }
        }

    }

    void Function()
    {
        SceneManager.LoadScene("Title");
    }
}
