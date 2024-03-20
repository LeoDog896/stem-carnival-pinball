using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject me;
    // Start is called before the first frame update
    void Start()
    {
        if ((int)Random.Range(0, 11) <= 3)
        {
            Instantiate(me);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
