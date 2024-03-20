using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class overText : MonoBehaviour
{
    string actualText;
    public Text textBox;
    int iDunnoWhatToCallThisVariableSoIGaveItALongName;
    // Start is called before the first frame update
    void Start()
    {
        iDunnoWhatToCallThisVariableSoIGaveItALongName = (int)Random.Range(0, 101);

        if(iDunnoWhatToCallThisVariableSoIGaveItALongName<=50)
        {
            actualText = "The House Always Wins";
        }
        else if(iDunnoWhatToCallThisVariableSoIGaveItALongName<=80)
        {
            actualText = "99% of players quit before they win";
        }
        else if(iDunnoWhatToCallThisVariableSoIGaveItALongName<=90)
        {
            actualText = "You can't succeed if you quit";
        }
        else if(iDunnoWhatToCallThisVariableSoIGaveItALongName<=98)
        {
            actualText = "9/10 Gamblers recommend playing again";
        }
        else
        {
            actualText = "Lol, you really thought you could win?";
        }
        textBox.text = actualText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
