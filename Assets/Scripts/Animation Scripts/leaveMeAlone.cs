using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaveMeAlone : MonoBehaviour
{
    Rigidbody2D rb;
    
    void Start()
    {
        Vector2 jump = new Vector2(Random.Range(-20.0f, 20.0f), Random.Range(30.0f, 40.0f));
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(jump, ForceMode2D.Impulse);
    }
}
