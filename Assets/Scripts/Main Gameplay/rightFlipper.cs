using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightFlipper : MonoBehaviour
{
    Rigidbody2D rb;
    float powa;
    public bool auto;
    // Start is called before the first frame update
    void Start()
    {
        powa = 200.0f;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            rb.AddTorque(-powa);
        }
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (auto)
        {
            rb.AddTorque(powa);

        }
    }
}
