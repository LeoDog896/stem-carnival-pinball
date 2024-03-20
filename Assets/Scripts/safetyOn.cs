using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class safetyOn : MonoBehaviour
{

    GameObject save;
    // Start is called before the first frame update
    void Start()
    {
        save = GameObject.FindWithTag("safe");
        if (save != null)
        {
            DontDestroyOnLoad(save);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
