using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour {

    public void StartGame()
    {
        //this will load the 1st level
        SceneManager.LoadScene("Level 1");
        //reset the lives 
        PlayerPrefs.DeleteKey("lives");
    }
}


