using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballScript : MonoBehaviour
{
    //WARNING: THIS CODE WAS CREATED WITH ME HALF ASLEEP, MAY CONTAIN UNREADABLE CODE. I WILL NOT APOLOGIZE. 
    public GameObject x1, x2, x3;
    AudioSource musicPlayer;
    public AudioClip main, vaultMusic, roulSound;
    public AudioSource rouletteAudio, boostAudio, rouletteRoll, policeSound;
    public GameObject r, b;
    float gameTimer;
    bool isActive;
    //Camstuff
    float min = 0, max = 10;
    public GameObject blackScreen, pityText, roul;
    int direction, speed, lives;
    public GameObject cam, start;
    bool Passing, isDead;
    int hits;
    GameObject destroyPity, checkRoul;
    public Text scoreView;
    int score = 0;
    int hit;
    double multiplierVal;
    public bool auto;



    //Roulette stuff
    int possibilities;
    Vector2 rouletteLaunch;
    float doubleTimer;
    float rouletteRange;
    public GameObject rb79;
    public bool trial;
    bool roulTimerNeeded;
    GameObject rouletteAudioController;
    public AudioClip rolling;
    float rouletteTimer;
    //animation 
    Animator myAnim;
    GameObject lifeAsset;
    float jumpTimer;

    //ballstuff
    Rigidbody2D rb;
    bool atStart;
    Vector2 jump, boost, miniboost, vaultLaunch;
    public GameObject wall;
    GameObject destroyWall;
    public GameObject rouller;
    // Start is called before the first frame update
    void Start()
    {
       rouletteTimer = 2.0f;
        roulTimerNeeded = false;
        gameTimer = 0;
        isActive = false;
        rouller = GameObject.FindWithTag("roulette");
        rouletteRoll = rouller.GetComponent<AudioSource>();
        rouletteAudioController = GameObject.FindWithTag("rouletteAudio");
        rouletteAudio = rouletteAudioController.GetComponent<AudioSource>();
        rouletteAudio.clip = roulSound;
        //camstuff
        lives = 2;
        direction = 0;
        Passing = false;
        isDead = false;
        speed = 20;
        destroyPity = null;
        jumpTimer = 3.0f;

        musicPlayer = cam.GetComponent<AudioSource>();
        musicPlayer.clip = main;

        //roulette stuff
        multiplierVal = 1;
        doubleTimer = 20.0f;
        rouletteRange = 10.0f;


        //Score stuff
        //scoreStuff
        scoreView.text = "0";

        //ballstuff
        miniboost = new Vector2(-Random.Range(-5, 5), 0);
        rb = GetComponent<Rigidbody2D>();
        atStart = true;
        //JUMP
        jump = new Vector2(0, Random.Range(73, 76));
        hits = 0;
        boost = new Vector2(0, 15);


        //animation stuffs
        lifeAsset = GameObject.FindWithTag("lives");
        myAnim = lifeAsset.GetComponent<Animator>();
        myAnim.SetInteger("lives", lives);

       

    }
    

    //camstuff
    void FixedUpdate()
    {
        if (rouletteTimer > 0 && roulTimerNeeded)
        {
            rouletteTimer -= Time.deltaTime;
        }
        if (rouletteTimer <= 0 && roulTimerNeeded)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rouletteLaunch = new Vector2(Random.Range(0, rouletteRange), Random.Range(-rouletteRange, rouletteRange));
            rb.AddForce(rouletteLaunch, ForceMode2D.Impulse);
            roulTimerNeeded = false;
            rouletteTimer = 2.0f;

            rewardPlayer();
            if (rouller != null)
            {
                Destroy(rouller);
            }

        }


        //jump


        if (((Input.GetAxis("Jump") == 1) || auto) && atStart)
        {
            if(auto && (jumpTimer<=0))
            {
                jump = new Vector2(0, Random.Range(13, 16));
                rb.AddForce(jump, ForceMode2D.Impulse);
                atStart = false;
                jumpTimer = 3.0f;
            }
            else if(!auto)
            {
                jump = new Vector2(0, Random.Range(13, 16));
                rb.AddForce(jump, ForceMode2D.Impulse);
                atStart = false;
            }
            

            if(jumpTimer>0)
            {
                jumpTimer -= Time.deltaTime;
            }

        }

        //multiplier timer
        if (multiplierVal > 1)
        {
            doubleTimer -= Time.deltaTime;
            if (doubleTimer <= 0)
            {
                multiplierVal = 1;
                doubleTimer = 20.0f;
                GameObject multiplier = GameObject.FindWithTag("multiplier");
                Destroy(multiplier);
                //Debug.Log("Double Time is up");
            }
        }




        if (isActive)
        {
            gameTimer += Time.deltaTime;
        }
        if (Passing)
        {
            cam.transform.Translate(0, speed * Time.deltaTime * direction, 0);
            if (cam.transform.position.y >= max || cam.transform.position.y <= min)
            {
                Passing = false;
            }
        }


        if(gameObject.transform.position.y<(cam.transform.position.y - 4.5f) && ((cam.transform.position.y > 0)) && ((cam.transform.position.y < 10)))
        {
            direction = -1;
            Passing = true;
        }

        //I don't remember writing this, but it works.
        if (gameObject.transform.position.y > 5 && cam.transform.position.y <= 0)
        {
            direction = 1;
            Passing = !false;
        }
        else if (gameObject.transform.position.y < 5 && cam.transform.position.y >= 10)
        {
            direction = -1;
            Passing = !false;
        }

        if (isDead)
        {
            cam.transform.Translate(0, speed * Time.deltaTime * -1, 0);
            
            if (cam.transform.position.y <= -10)
            {
                Instantiate(r);
                Instantiate(b);
                policeSound.Play();
                isDead = false;
                Invoke("FadeBlack", 1.0f);

            }
        }
    }


    //decides the value of the roulette launcher force
    void rouletteLauncher()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.transform.position = rouller.transform.position;
        rouletteRoll.clip = rolling;
        rouletteRoll.Play();
        roulTimerNeeded = true;
        
        
       
    }
    //End of launch

    //Manages player reward
    void rewardPlayer()
    {
        rouletteAudio.Play();
        int prizeVal = (int)Random.Range(0, 100);

        if (prizeVal >= 90)
        {
            //Debug.Log("Triple Points");
            multiplierVal = 3;
            Instantiate(x3);
        }
        else if(prizeVal>=60)
        {
            //Debug.Log("Double points");
            multiplierVal = 2;
            Instantiate(x2);
        }
        else if (prizeVal <=20)
        {
            //Debug.Log("Prize: Extralife");
            if (lives < 5)
            {
                lives++;

                myAnim.SetInteger("lives", lives);
            }
            else
            {
                multiplierVal = multiplierVal + .5;
                //Debug.Log("Lives overload");
                Instantiate(x1);
            }
        }
        else
        {
            //Debug.Log("default");
            multiplierVal = multiplierVal + .5;
            Instantiate(x1);
        }
       // Debug.Log("PrizeVal = " + prizeVal);


        
    }
    //End Player prize


    
    //gameover fade
    void FadeBlack()
    {
        Instantiate(blackScreen);
    }


    void spawnGambler()
    {
        checkRoul = GameObject.FindWithTag("roulette");
        if (checkRoul == null)
        {
            Instantiate(roul);
            rouller = GameObject.FindWithTag("roulette");

            rouletteRoll = rouller.GetComponent<AudioSource>();

        }
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if(otherObject.gameObject.CompareTag("sider"))
        {
            rb.AddForce(new Vector2(-Random.Range(3,7), Random.Range(-3,0)), ForceMode2D.Impulse);
        }
        if (otherObject.gameObject.CompareTag("roulette"))
        {
            //THE ROULETTE STUFF
            if((transform.position.y>otherObject.gameObject.transform.position.y) && (cam.transform.position.y!=0))
            {
                direction = -1;
                Passing = true;
            }
            hits = 1;
            rouletteLauncher();


        }

            //ballstuff
            if (otherObject.gameObject.CompareTag("ventExit"))
            {
                Invoke("installWallSuddenly", 0.5f);
            miniboost = new Vector2(-Random.Range(-5, 5), 0);
            rb.AddForce(miniboost, ForceMode2D.Impulse);
                musicPlayer.Play();
                isActive = true;

            }
            if (otherObject.gameObject.CompareTag("boost"))
            {

                if (gameObject.transform.position.y < (otherObject.gameObject.transform.position.y + 0.3f) || transform.position.x < otherObject.gameObject.transform.position.x)
                {
                boostAudio.Play();
                    rb.AddForce(boost, ForceMode2D.Impulse);
                }

            }

            if (otherObject.gameObject.CompareTag("death"))
            {
                lives--;
                //Debug.Log("Death has been registered");
                destroyWall = GameObject.FindWithTag("0");
                destroyPity = GameObject.FindWithTag("pity");
                musicPlayer.Stop();
                multiplierVal = 1;
                
                isActive = false;
                spawnGambler();
                GameObject multiplier = GameObject.FindWithTag("multiplier");
                
                if(multiplier!=null)
                {
                    Destroy(multiplier);
                }

            if (destroyWall != null)
                {
                    Destroy(destroyWall);
                }
            if (destroyPity!=null)
                {
                    Destroy(destroyPity);
                }
            
            
                if (lives < 0)
                {
                    isDead = true;
                    //Debug.Log("Dead");
                }
                else if(lives>=0)
                {
                    if(lives<2)
                    {
                        pityBall();
                    }
                    
                    transform.position = start.transform.position;
                    atStart = true;
                    
                }
                

                    myAnim.SetInteger("lives", lives);

            }

        
    }

        void installWallSuddenly()
        {
            if(transform.position.x<5)
            {
                Instantiate(wall);
            }
            
        }

        void OnCollisionEnter2D(Collision2D otherObject)
        {
            if (otherObject.gameObject.CompareTag("1"))
            {
                hits++;
            }

            if(otherObject.gameObject.CompareTag("start"))
            {
            atStart = true;
            }


        //roulette
        if (otherObject.gameObject.CompareTag("1Pointer"))
        {
            score += (int)(1 * multiplierVal);

            scoreView.text = "" + score;
        }
        if (otherObject.gameObject.CompareTag("5Pointer"))
        {
            score += (int)( 50 * multiplierVal);

            scoreView.text = "" + score;
        }
        if (otherObject.gameObject.CompareTag("10Pointer"))
        {
            
                score += (int)(100 * multiplierVal);
            

            scoreView.text = "" + score;
        }
        if (otherObject.gameObject.CompareTag("20Pointer"))
        {
            
                score += (int)(200 * multiplierVal); 
            
            scoreView.text = "" + score;
        }
        if (otherObject.gameObject.CompareTag("50Pointer"))
        {
            
            
                score +=(int) (500 * multiplierVal);

            spawnGambler();
            scoreView.text = "" + score;
            //Vault launch
            vaultLaunch = new Vector2(Random.Range(-4, 4), Random.Range(-3, -6));
            rb.AddForce(vaultLaunch, ForceMode2D.Impulse);
        }
        if (otherObject.gameObject.CompareTag("S5Pointer"))
        {
            score += (int)(5 * multiplierVal);
            scoreView.text = "" + score;
            rb.AddForce(new Vector2(-5, -7), ForceMode2D.Impulse);
        }
        if (otherObject.gameObject.CompareTag("S10Pointer"))
        {
            score += (int)(10 * multiplierVal);
            rb.AddForce(new Vector2(-5, -7), ForceMode2D.Impulse);
            scoreView.text = "" + score;
        }

    }



    
    void pityBall()
    {
        if(gameTimer<=5.0f)
        {
            lives++;
            myAnim.SetInteger("lives", lives);
            //Debug.Log("Loser, try again" + " Lives: " + lives);
            Instantiate(pityText);
        }
        else
        {
            if (hits <= 1)
            {
                if ((int)Random.Range(0, 2) == 0)
                {
                    lives++;
                    myAnim.SetInteger("lives", lives);
                    //Debug.Log("Loser, try again" + " Lives: " + lives);
                    Instantiate(pityText);
                }
            }
            else if (hits < 3)
            {
                //Debug.Log("Standard");

                if ((int)Random.Range(0, 3) == 0)
                {
                    lives++;
                    myAnim.SetInteger("lives", lives);
                    //Debug.Log("Loser, try again" + " Lives: " + lives);
                    Instantiate(pityText);
                }
            }
            else if (hits <= 7)
            {
                //Debug.Log("Mmm, potato");
                if (Random.Range(0, 10) > 9)
                {
                    lives++;
                    myAnim.SetInteger("lives", lives);
                    //Debug.Log("Loser, try again" + " Lives: " + lives);
                    Instantiate(pityText);
                }
            }
        }
        
        hits = 0;

        gameTimer = 0.0f;
    }




}
