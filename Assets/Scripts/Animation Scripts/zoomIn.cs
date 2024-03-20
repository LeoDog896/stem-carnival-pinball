using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomIn : MonoBehaviour
{
    float wait;
    bool beginZoom;
    int countLvl;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        wait = 4.6f;
        countLvl = 1;
        speed = 0.7F;
        beginZoom = !true;
    }

    // Update is called once per frame
    void Update()
    {
        wait -= (Time.deltaTime);
        Debug.Log(wait);
        if (wait <= 0 && countLvl == 1)
        {
            beginZoom = true;
        }

        if (beginZoom)
        {
            transform.localScale += new Vector3(Time.deltaTime*speed, Time.deltaTime*speed, 0);
            wait = 5.0f;
            countLvl++;
            Debug.Log("ZOOM, PLEASE");
        }
        if (wait <= 0 && countLvl == 2)
        {
            Destroy(gameObject);
        }
    }
}
