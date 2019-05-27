using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ContinueBtn2 : MonoBehaviour {

    public void ContinueGame()
    {

        //this will load the highscore screen 
        SceneManager.LoadScene("HighScore");
        //reset the lives 
        PlayerPrefs.DeleteKey("lives");


    }

}
