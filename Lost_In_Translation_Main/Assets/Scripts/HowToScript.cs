using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//scene management 
using UnityEngine.SceneManagement;

public class HowToScript : MonoBehaviour {

    public void HowToPlay()
    {

        //this will take the player to the how to play scene
        SceneManager.LoadScene("HowToPlay");



    }
}
