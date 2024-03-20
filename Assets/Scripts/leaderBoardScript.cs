using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Uncalled doesn't work as needed
public class leaderBoardScript : MonoBehaviour
{
    //OMFG, this is probably the most frustrating POS script in the entire project. 
    //ngl, at this point, only god knows how this works. It's almost 300 lines of code. 
    string[,] topFive;
    char[] characters;
    bool input, charOnCooldown;
    int score, leaderBoardStage, scoreIndex, charInd;
    float charCooldown, cooldownVal;
    static float igt = 0.0f;
    Text scoreView;
    Text first, second, third, fourth, fifth;
    bool uncalled, scoreLocated;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("IMPORTANT Start: " + SceneManager.GetActiveScene().name);
            charInd = 0;
            //CHANGE THIS TO CONTROL WAIT BETWEEN CHARACTER INPUTS
            cooldownVal = 1.0f;
            charCooldown = cooldownVal;
        uncalled = true;
        Debug.Log("IMPORTANT " + uncalled + " at " + SceneManager.GetActiveScene().name);
        Debug.Log("IMPORTANT Time: " + igt);
        leaderBoardStage = 1;
            charOnCooldown = false;
            scoreLocated = false;
        input = false;
            
            characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ.!?".ToCharArray();
            
        if(SceneManager.GetActiveScene().name.Equals("preTitle"))
        {
            Debug.Log("Pretitle");
            topFive = new string[7, 2];
            
            //nums
            topFive[0, 1] = "" + -1;
            topFive[1, 1] = "" + -1;
            topFive[2, 1] = "" + -1;
            topFive[3, 1] = "" + -1;
            topFive[4, 1] = "" + -1;
            topFive[5, 1] = "" + -1;
            topFive[6, 1] = "" + -1;
            for (int i = 0; i <= 6; i++)
            {
                if (topFive[i, 0] == null)
                {
                    topFive[i, 0] = "N/A" + i;
                }


                for (int j = 0; j < 2; j++)
                {
                    Debug.Log(i + ", " + j + " = " + topFive[i, j]);
                }
            }
            
           SceneManager.LoadScene("Title");
           
        }
        

        //not working somhow
        /*
        if(SceneManager.GetActiveScene().name.Equals("Leaderboard") || SceneManager.GetActiveScene().name.Equals("VaultLeaderboard"))
        {
            

            if (uncalled)
            {
                Debug.Log("Hmm, this leaderboard is made of leaderboard");
            }
            int temp;
            scoreView = GameObject.FindWithTag("score").GetComponent<Text>();
            scoreView.text = "" + score;
            int.TryParse(topFive[6, 1], out temp);
            if (score > temp && uncalled && score != 0)
            {
                Debug.Log("At least you ain't the worst player. Unless...");
                topFive[6, 1] = "" + score;
                topFive[6, 0] = "---";
                Debug.Log("Name: " + topFive[6, 0] + "     Score: " + topFive[6, 1]);
                ActualSort();
                uncalled = false;
                input = true;
                Debug.Log("HasBeenCalled = " + !uncalled);
                score = 0;
            }

            //List them scores

            displayText();
        }
        */
            

        


    }

   

    void ActualSort()
    {
        //All these numbers are messing with my head, so idk how this bit works
        Debug.Log("IMPORTANT Initialize Sort");
        int  next, place, scoreCompare;
        string nextName, tempName;
        
        place = 5;
        int.TryParse(topFive[6, 1], out scoreCompare);
        int.TryParse(topFive[place, 1], out next);
        if(scoreCompare == score)
        {
            tempName = topFive[6, 0];

        }
        else
        {
            tempName = "NoName";
        }

        
        while (place>=0)
        {
            nextName = topFive[place, 0];
            if(score > next)
            {
                Debug.Log("Score: " + score + " > " + next);
                topFive[place + 1, 0] = nextName;
                topFive[place + 1, 1] = "" + next;
                topFive[place, 0] = tempName;
                topFive[place, 1] = "" + score;
                Debug.Log("Switch " + place + " and " + (place - 1));
            }
            place--;
            Debug.Log("Place: " + place);
            if(place>0)
            {
                int.TryParse(topFive[place, 1], out next);
            }
            displayText();
            
        }
    }

    //The part where you do the initials thing
    //Include checker to make sure name is appropriate as well
    void FixedUpdate()
    {
        igt += Time.deltaTime;
        if (input && (SceneManager.GetActiveScene().name.Equals("Leaderboard") || SceneManager.GetActiveScene().name.Equals("VaultLeaderboard")) && !uncalled)
        {
            //Find the blank in the leaderboard
            if (!scoreLocated)
            {
                for(int i = 0; i<5; i++)
                {
                    if (topFive[i, 0] == "---")
                    {
                        scoreIndex = i;
                        topFive[scoreIndex, 0] = "A--";
                        i = 5;
                        scoreLocated = true;
                    }
                }
                                
                            
            }
            //End

            //Changing the chars
            //Cooldown
            if (!charOnCooldown)
            {
                //Left 
                if (Input.GetKey(KeyCode.F))
                {
                    charInd--;
                    charOnCooldown = true;
                    if (charInd <= -1)
                    {
                        charInd = 28;
                    }
                }


                //Right
                if (Input.GetKey(KeyCode.J))
                {
                    charInd++;
                    charOnCooldown = true;
                    if (charInd >= 29)
                    {
                        charInd = 0;
                    }
                }
            }
            
            {
                charCooldown -= Time.deltaTime;

                if (charCooldown <= 0.0f)
                {
                    charOnCooldown = false;
                    charCooldown = cooldownVal;
                }
                
            }

            //Putting them in the name
            if (leaderBoardStage==1 && scoreLocated)
            {
                topFive[scoreIndex, 0] = characters[charInd] + "--";
                displayText();
                if(Input.GetAxis("Jump") ==1 && !charOnCooldown)
                {
                    leaderBoardStage = 2;
                    charOnCooldown = true;
                    charInd = 0;
                }
            }
            else if(leaderBoardStage == 2 && scoreLocated)
            {
                topFive[scoreIndex, 0] = topFive[scoreIndex, 0].Substring(0, 1) + characters[charInd] + "-";
                displayText();
                if (Input.GetAxis("Jump") == 1 && !charOnCooldown)
                {
                    leaderBoardStage = 3;
                    charOnCooldown = true;
                    charInd = 0;
                }
            }
            else if (leaderBoardStage == 3 && scoreLocated)
            {
                topFive[scoreIndex, 0] = topFive[scoreIndex, 0].Substring(0, 2) + characters[charInd];
                displayText();
                if (Input.GetAxis("Jump") == 1 && !charOnCooldown)
                {
                    leaderBoardStage = 4;
                }
            }
            else if (leaderBoardStage == 4 && scoreLocated)
            {
                input = false;
                charOnCooldown = true;
            }
        }
        //End of input
        else if (!input && (SceneManager.GetActiveScene().name.Equals("Leaderboard") || SceneManager.GetActiveScene().name.Equals("VaultLeaderboard")) && !uncalled)
        {
            if(Input.GetAxis("Jump") == 1 && !charOnCooldown)
            {

                SceneManager.LoadScene("Title");
            }
        }

        
        //Cooldown timer
        if (charOnCooldown)
        {
            charCooldown -= Time.deltaTime;

            if (charCooldown <= 0.0f)
            {
                charOnCooldown = false;
                charCooldown = cooldownVal;
            }

        }

    }


    void displayText()
    {
        //literally displays the leaderboard. Who could guess
        if (first == null)
        {

            first = GameObject.Find("1Text").GetComponent<Text>();
            second = GameObject.Find("2Text").GetComponent<Text>();
            third = GameObject.Find("3Text").GetComponent<Text>();
            fourth = GameObject.Find("4Text").GetComponent<Text>();
            fifth = GameObject.Find("5Text").GetComponent<Text>();
        }
        first.text = topFive[0, 0] + "                              " + topFive[0, 1];
        second.text = topFive[1, 0] + "                              " + topFive[1, 1];
        third.text = topFive[2, 0] + "                              " + topFive[2, 1];
        fourth.text = topFive[3, 0] + "                              " + topFive[3, 1];
        fifth.text = topFive[4, 0] + "                              " + topFive[4, 1];


    }


    void Update()
    {

        if (SceneManager.GetActiveScene().name.Equals("Leaderboard") || SceneManager.GetActiveScene().name.Equals("VaultLeaderboard"))
        {
            

            scoreView = GameObject.FindWithTag("score").GetComponent<Text>();

            int temp;
                if (score != 0)
                {
                    
                    scoreView.text = "" + score;
                    Debug.Log("Hmm, this leaderboard is made of leaderboard");
                }
                
                int.TryParse(topFive[6, 1], out temp);
                if ((score > temp) && uncalled)
                {
                    Debug.Log("At least you ain't the worst player. Unless...");
                    topFive[6, 1] = "" + score;
                    topFive[6, 0] = "---";
                    Debug.Log("IMPORTANT Name: " + topFive[6, 0] + "     Score: " + topFive[6, 1]);
                    ActualSort();

                    uncalled = false;
                    input = true;
                    Debug.Log("IMPORTANT HasBeenCalled = " + !uncalled);

                }
                else if(uncalled)
                {

                    displayText();
                input = false;
                uncalled = false;
                }

            
            
            
        }
            if(SceneManager.GetActiveScene().name.Equals("MainGameplay"))
                {
                    scoreView = GameObject.FindWithTag("score").GetComponent<Text>();
                    if (scoreView != null)
                    {
                        int.TryParse(scoreView.text, out score);
                    }
                }
            
            
        

       
        

    }

}
