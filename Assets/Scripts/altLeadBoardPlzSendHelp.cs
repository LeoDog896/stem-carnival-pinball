using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class altLeadBoardPlzSendHelp : MonoBehaviour
{
    //I feel like re-writing a script that is awful because it was written at 3am is not a good idea when it's 1:40am, but whatever...

    //Hello, 12:19 Erick here, I am so gonna hate myself later. But that is not my problem. In case I go missing, the password is p0t@toes. 

    //Array holds the leaderboard
    static string[,] topFive;
    //Array holds character options
    char[] characters;



    //The text for the score
    Text scoreView;
    //The text for the actual leaderboard positions
    Text first, second, third, fourth, fifth;


    //These vars could be problematic in the future
    bool input, charOnCooldown;
    int score, leaderBoardStage, scoreIndex, charInd;
    float charCooldown, cooldownVal, coolDown;
    bool uncalled, scoreLocated;


    // Start is called before the first frame update
    //This part probably works... idk for sure tho
    void Start()
    {
        //Identifies the scene
        Debug.Log("IMPORTANT Start: " + SceneManager.GetActiveScene().name);

        //set the basic variables (they likely won't be set for gameOver scene and leaderboard scenes because they are loaded by another script.
        charInd = 0;
        leaderBoardStage = 1;



        //probably the most problematic var
        uncalled = true;
        Debug.Log("IMPORTANT LEADERBOARD Uncalled: " + uncalled + ", leaderBoardStage: " + leaderBoardStage + " at " + SceneManager.GetActiveScene().name);

        charOnCooldown = false;
        scoreLocated = false;
        input = true;
        //CHANGE THIS TO CONTROL WAIT BETWEEN CHARACTER INPUTS
        cooldownVal = 0.7f;
        charCooldown = cooldownVal;



        //Could become problematic second playthrough, idk for sure
        //Should only ever be used once
        //Fill the leaderboard with temp values if it's the pretitle scene
        if (SceneManager.GetActiveScene().name.Equals("preTitle"))
        {
            //Filling that char array
            characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ.!?".ToCharArray();

            Debug.Log("Pretitle");
            topFive = new string[7, 2];

            

            //Filling the names
            for (int i = 0; i <= 6; i++)
            {
                //If the slot doesn't exist, make it exist
                if (topFive[i, 0] == null )
                {
                    topFive[i, 0] = "N/A" + i;
                }
                if(topFive[i, 1] == null)
                {

                    topFive[i, 1] = "" + -i;
                }

                //Checking the values as they are filled in
                for (int j = 0; j <=1; j++)
                {
                    Debug.Log(i + ", " + j + " = " + topFive[i, j]);
                }
            }

            SceneManager.LoadScene("Title");


        }
    }
    //End of start function

    // Update is the most likely to be an issue
    //Actually, it's probably the sort, but then again, I just finished my coffee. Maybe my brain is already screwed. 
    //^I take that back, idk where the sort is wrong. It has to be this. 
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Leaderboard") || SceneManager.GetActiveScene().name.Equals("VaultLeaderboard"))
        {
            //Only runs when on leaderboard
            if(uncalled)
            {

                int temp;
                scoreView = GameObject.FindWithTag("score").GetComponent<Text>();
                scoreView.text = "" + score;
                int.TryParse(topFive[6, 1], out temp);
                Debug.Log("And right in front of you, the " + SceneManager.GetActiveScene().name);
                //if score is greater than 7th, replace 7th with your score
                Debug.Log("IMPORTANT Score: " + score);
                Debug.Log("IMPORTANT last score: " + temp);

                if (score > temp)
                {
                    Debug.Log("IMPORTANT Hey, this one ain't that bad");
                    topFive[6, 1] = "" + score;
                    topFive[6, 0] = "---";
                    Debug.Log("IMPORTANT Name: " + topFive[6, 0] + "     Score: " + topFive[6, 1]);


                    //changing the important variables
                    uncalled = false;

                    //start sort
                    ActualSort();

                    
                    Debug.Log("IMPORTANT LEADERBOARD HasBeenCalled = " + !uncalled);

                }
                else
                {
                    //"Should" prevent issues if you aren't on the board and lets you go back to the title
                    displayText();
                    input = false;
                    uncalled = false;
                }
            }

        }
        //end of leaderboard Update
        if (SceneManager.GetActiveScene().name.Equals("MainGameplay"))
        {
            //steals the score from the score text in the main gameplay scene
            scoreView = GameObject.FindWithTag("score").GetComponent<Text>();
            if(scoreView != null)
            {
                int.TryParse(scoreView.text, out score);
                Debug.Log("Score: " + score);
            }
        }
        //end of main gameplay update
    }


    //Literally everything under this makes sense to me rn. 


    void FixedUpdate()
    {
        if(input && (SceneManager.GetActiveScene().name.Equals("Leaderboard") || SceneManager.GetActiveScene().name.Equals("VaultLeaderboard")) && !uncalled)
        {
            ///allows you to put your name in the leaderboard
            //should only happen if the player is on leaderboard or checked to see if it could be on the leaderboard
            


            //Taking inputs to change the characters
            if(!charOnCooldown)
            {

                //left
                if(Input.GetKey(KeyCode.F))
                {
                    charInd--;
                    charOnCooldown = true;

                    //loops the array
                    if (charInd <= -1)
                    {
                        charInd = 28;
                    }
                }

                //right
                if(Input.GetKey(KeyCode.J))
                    {
                    charInd++;
                    charOnCooldown = true;

                    //loops the array
                    if (charInd >= 29)
                    {
                        charInd = 0;
                    }
                }
            }
            //End of taking inputs
            //cooldown
            else
            {
                
                charCooldown -= Time.deltaTime;

                if (charCooldown <= 0.0f)
                {
                    charOnCooldown = false;
                    charCooldown = cooldownVal;
                }

            }
            //end of cooldown
            //Putting them in the name
            if (leaderBoardStage == 1 && scoreLocated)
            {
                topFive[scoreIndex, 0] = characters[charInd] + "--";
                displayText();
                if (Input.GetAxis("Jump") == 1 && !charOnCooldown)
                {
                    leaderBoardStage = 2;
                    charOnCooldown = true;
                    charInd = 0;
                }
            }
            else if (leaderBoardStage == 2 && scoreLocated)
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
                    
                    charInd = 0;
                    leaderBoardStage = 1;



                    //probably the most problematic var
                    uncalled = true;
                    Debug.Log("IMPORTANT LEADERBOARD Uncalled: " + uncalled + ", leaderBoardStage: " + leaderBoardStage + " at " + SceneManager.GetActiveScene().name);

                    charOnCooldown = false;
                    scoreLocated = false;
                    input = true;
                    SceneManager.LoadScene("Title");

                }
            }
            



        }
        //end of input section

        else if(!(input || uncalled) && (SceneManager.GetActiveScene().name.Equals("Leaderboard") || SceneManager.GetActiveScene().name.Equals("VaultLeaderboard")))
        {
            if (Input.GetAxis("Jump") == 1 && !charOnCooldown)
            {
                
                SceneManager.LoadScene("Title");
                score = 0;
                Debug.Log("IMPORTANT Returning to title, score is reset to: " + score);
            }
        }
    }


    

    //Likely the problem

    //Update, this is the problem (currently) because it doesn't wanna sort
    void ActualSort()
    {
        ///Exists to check for sorting errors
        string listHolder ="";
        Debug.Log("ActualSort() called");


        int place, higherPlace;
        string tempName;
        for(int i = 6; i>0; i--)
        {
            int.TryParse(topFive[i, 1], out place);
            int.TryParse(topFive[i - 1, 1], out higherPlace);
            if (place>higherPlace)
            {
                tempName = topFive[i-1, 0];
                topFive[i - 1, 0] = topFive[i, 0];
                topFive[i - 1, 1] = "" + place;
                topFive[i, 0] = tempName;
                topFive[i, 1] = "" + higherPlace;
            }
        }
        
        ///Checking for sorting errors
        for(int i = 6; i>=0; i--)
        {
            listHolder = listHolder + topFive[i, 0] + ":" + topFive[i, 1] + ",   ";
        }
        Debug.Log(listHolder);


        //Check the scoreboard for your score
        if (!scoreLocated)
        {
            for (int i = 4; i >= 0; i--)
            {
                if (topFive[i, 0] == ("---"))
                {
                    scoreIndex = i;
                    topFive[scoreIndex, 0] = "A--";
                    i = -1;
                    scoreLocated = true;
                    input = true;
                    Debug.Log("Score is in top 5");
                }
            }
        }
        //score is found

        displayText();





            /* CODE REMOVED DUE TO I DON'T KNOW WHERE IT IS WRONG
            ///Method should be called after checking if the player's score is higher than 
            int next, current, place, temp;
            string nextName, currentName, tempName;

            //Start 1 above when testing the scores
            place = 5;
            int.TryParse(topFive[6, 1], out current);
            int.TryParse(topFive[5, 1], out next);

        
           //Start sorting
            while (place >= 0)
            {

                //What's next?
                    int.TryParse(topFive[place, 1], out next);
                    int.TryParse(topFive[place + 1, 1], out current);
                    currentName = topFive[place + 1, 0];
                    nextName = topFive[place, 0];
            

                if (current > next)
                {
                    temp = next;
                    tempName = nextName;
                
                    Debug.Log("Score: " + current + " > " + next);
                    topFive[place, 0] = currentName;
                    topFive[place, 1] = "" + current;
                    topFive[place + 1, 0] = tempName;
                    topFive[place + 1, 1] = "" + temp;
                
                    Debug.Log("Switch " + place + " and " + (place - 1));
                }
           
               place--;
            
                Debug.Log("Place: " + place);
                //Display sorted leaderboard
                displayText();
       

        }
             */
            //done sorting


    }

    void displayText()
    {
        //literally displays the leaderboard. Who could guess

        Debug.Log("displayText() called");
            first = GameObject.Find("1Text").GetComponent<Text>();
            second = GameObject.Find("2Text").GetComponent<Text>();
            third = GameObject.Find("3Text").GetComponent<Text>();
            fourth = GameObject.Find("4Text").GetComponent<Text>();
            fifth = GameObject.Find("5Text").GetComponent<Text>();
        
        first.text = topFive[0, 0] + "                              " + topFive[0, 1];
        second.text = topFive[1, 0] + "                              " + topFive[1, 1];
        third.text = topFive[2, 0] + "                              " + topFive[2, 1];
        fourth.text = topFive[3, 0] + "                              " + topFive[3, 1];
        fifth.text = topFive[4, 0] + "                              " + topFive[4, 1];


    }

    


    //Close class
}
