using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracker : MonoBehaviour
{
    GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("cam");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(-6.36f, cam.transform.position.y - 3.29f, 0);
    }
}
