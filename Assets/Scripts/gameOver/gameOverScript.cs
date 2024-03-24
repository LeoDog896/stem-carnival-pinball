using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    float t;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(t>=1.0f)
        {
            GameOverSceneChange();
        }
        else
        {
            t += 0.03f;
        }

        
    }


    void GameOverSceneChange()
    {
        Debug.Log("GameOver");
        SceneManager.LoadScene("gameOver");
    }
}