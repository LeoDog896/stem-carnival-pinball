using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D otherObject)
    {


        if (otherObject.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
