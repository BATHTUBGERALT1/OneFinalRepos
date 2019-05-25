using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour {

    public void ContinueGame()
    {

        //this will load the 2nd level
        SceneManager.LoadScene("Level 2");
        //reset the lives 
        PlayerPrefs.DeleteKey("lives");


    }
	
}
