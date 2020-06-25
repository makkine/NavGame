using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

 public class boat_UI : MonoBehaviour
{

    public string myString;
    public Text myText;
    public float fadeTime;
    public bool displayInfo;
    public bool riding;
    public PController rider;


    void Start()
    {
        myText = GameObject.Find("Text").GetComponent<Text>();
        myText.color = Color.clear;

    }

    void Update()
    {
        FadeText();
// Right now this works from anywhere on the map, move to OnTriggerEnter or something
        if (displayInfo && Input.GetKeyUp(KeyCode.X))
        {
            displayInfo = false;
            rider.transform.position = transform.position;
            riding = true;
            rider.onBoat = true;
        }

        if(riding)
        {
            Vector3 pos = rider.transform.position;
            pos.y = -5.05f;
            transform.position = pos;
            transform.rotation = rider.transform.rotation;
        }

    }

    void OnTriggerEnter()
    {
        displayInfo = true;
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