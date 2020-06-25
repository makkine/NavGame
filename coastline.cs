using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class coastline : MonoBehaviour
{

    public string myString;
    public Text myText;
    public float fadeTime;
    public bool displayInfo;
    public boat_UI boat;

    void Start()
    {
        myText = GameObject.Find("CoastText").GetComponent<Text>();
        myText.color = Color.clear;

    }

    void Update()
    {
        FadeText();
        // Right now this works from anywhere on the map, move to OnTriggerEnter or something
        if (displayInfo && Input.GetKeyUp(KeyCode.X))
        {
            displayInfo = false;
            boat.riding = false;
        }

    }

    void OnTriggerEnter()
    {
        if(boat.riding) {
            displayInfo = true;
        }
        
    }

    void OnTriggerExit()
    {
        displayInfo = false;
    }

    void FadeText()

    {
        if (displayInfo)
        {
            myText.text = myString;
            myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
        }

        else
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
        }

    }


}