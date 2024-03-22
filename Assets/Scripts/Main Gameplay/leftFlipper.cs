using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftFlipper : MonoBehaviour
{
    Rigidbody2D rb;
    float powa;
    public bool auto;
    // Start is called before the first frame update
    void Start()
    {
        
        powa = 20000.0f;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.F) || (Input.GetAxis("left") == 1))
        {
            Debug.Log("Left Flipper");
            rb.AddTorque(powa);

        }
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if(auto)
        {
            Debug.Log("Left Flipper Auto");
            rb.AddTorque(powa);

        }
    }
}
