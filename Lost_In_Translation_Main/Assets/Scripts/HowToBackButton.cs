using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToBackButton : MonoBehaviour {

    public void BackButton()
    {

        //this will load the 1st level
        SceneManager.LoadScene("Main Menu");
     


    }
}
