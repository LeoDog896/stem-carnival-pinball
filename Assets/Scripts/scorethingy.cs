using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scorethingy : MonoBehaviour
{
    Text scoreView, highScore;
    int score = 0;
    int[] highscore;
    bool uncalled;
    // Start is called before the first frame update
    void Start()
    {
        
        if (SceneManager.GetActiveScene().name.Equals("preTitle"))
        {
            highscore = new int[2];
            highscore[0] = 0;
            highscore[1] = 0;
            uncalled = true;
            SceneManager.LoadScene("Title");
        }
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (SceneManager.GetActiveScene().name.Equals("MainGameplay"))
        {
            //steals the score from the score text in the main gameplay scene
            scoreView = GameObject.FindWithTag("score").GetComponent<Text>();
            if (scoreView != null)
            {
                int.TryParse(scoreView.text, out score);
            }
        }

        if(SceneManager.GetActiveScene().name.Equals("scoreScene") || SceneManager.GetActiveScene().name.Equals("scoreScene2"))
        {
            if (uncalled)
            {
            order();
            showScore();
            }
            if(Input.GetAxis("Jump") == 1 )
            {
                uncalled = true;
                SceneManager.LoadScene("Title");
            }
            
        }
        

    }
    void showScore()
    {
        scoreView = GameObject.FindWithTag("score").GetComponent<Text>();
        if (scoreView != null)
        {
            scoreView.text = ""+score;
        }
        highScore = GameObject.FindWithTag("hS").GetComponent<Text>();
        highScore.text = "" + highscore[0];
        
    }
    void order()
    {
        highscore[1] = score;

        if(highscore[1]> highscore[0])
        {
            highscore[0] = highscore[1];
        }
        uncalled = false;
    }
}
