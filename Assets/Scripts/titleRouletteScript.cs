using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleRouletteScript : MonoBehaviour
{
    Animator myAnim;
    int eger;
    int cat;
    public GameObject catPrefab;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        cat = (int)Random.Range(0.0f, 21.0f);
        eger = (int)Random.Range(0.0f, 31.0f);
        Debug.Log(""+eger);
        if (eger==0)
        {
            
            myAnim.SetBool("isTheySpecial", true);
        }
        if (cat ==0)
        {
            Instantiate(catPrefab);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
