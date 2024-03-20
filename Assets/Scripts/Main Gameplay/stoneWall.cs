using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneWall : MonoBehaviour
{
    int hits;
    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {


        if (otherObject.gameObject.CompareTag("Player"))
        {
            hits++;
            if(hits>=2)
            {
                Destroy(gameObject);
            }
        }
    }
            // Update is called once per frame
            void Update()
    {
        
    }
}
