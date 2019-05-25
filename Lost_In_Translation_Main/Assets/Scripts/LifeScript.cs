using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//uses the unity engine
using UnityEngine.UI;

public class LifeScript : MonoBehaviour {

    //this is for the number of lives
    public Text livesText;
    private int numericalLives = 0;


    // Use this for initialization
    void Start()
    {
        numericalLives = PlayerPrefs.GetInt("lives", 0);
        livesText.text = numericalLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //every time the played dies add one
    public void LoseLife()
    {
        numericalLives = numericalLives + 1;

        livesText.text = numericalLives.ToString();

    }

    //this saves the lives
    public void SaveLives()
    {

        PlayerPrefs.SetInt("lives", numericalLives);

    }

    //game is over when its = to 0 
    public bool isGameOver()
    {
        if (numericalLives <= 0)
        {

            return true;
        }
        else
        {
            return false;

        }

    }
}