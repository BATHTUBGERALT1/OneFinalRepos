using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour {

    //text mesh pro variables 
    public TextMeshProUGUI textDisplay;

    //actions of the text
    public string[] sentences;
    private int index;
    public float typingSpeed;

    //this is for the continuing of the text, so it goes to each line
    public GameObject continueButton;
    void Start()
    {

        StartCoroutine(Type());

    }
    //displays the sentences, and the continue button shows once sentence is done
    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);

        }
    }

    //this is for the speed and display of each letter and sentences
    IEnumerator Type()
    {

        foreach(char letter in sentences[index].ToCharArray())
        {

            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }

    }
    //
    public void NextSentence()
    {

        continueButton.SetActive(false);
        if(index < sentences.Length - 1)
        {

            index++;
            textDisplay.text = "";
            StartCoroutine(Type());


        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }


    }
	// Use this for initialization


}
