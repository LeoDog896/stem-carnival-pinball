using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeet : MonoBehaviour
{
    Rigidbody2D rb;
    bool loaded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        loaded = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Fire1") == 1 && loaded)
        {

            //jump
            Vector2 jump = new Vector2(0, 10);
            rb.AddForce(jump, ForceMode2D.Impulse);
            loaded = false;
            Debug.Log("Check loaded Post Fire: " + loaded);
        }
        if (Input.GetAxis("Fire2") == 1 && !loaded)
        {
            loaded = true;
            Debug.Log("Check loaded: " + loaded);
        }

    }
}
