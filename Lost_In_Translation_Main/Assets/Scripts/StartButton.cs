using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour {

    public void StartGame()
    {
        PlayerPrefs.SetInt("carryscore", 0);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.Save();

        //this will load the 1st level
        SceneManager.LoadScene("Level 1");
        //reset the lives 
        PlayerPrefs.DeleteKey("lives");
    }
}


