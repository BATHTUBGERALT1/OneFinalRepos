﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using statement for the use of ui
using UnityEngine.UI;

public class Silver_Scroll : MonoBehaviour {


    //for the score object
    public Score scoreObject;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Unity calls this function when coin touches any other object in the game
    // If the player touched the coin, it should vanish and the score should increase
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the thing we touched was the player 
        Player playerScript = collision.collider.GetComponent<Player>();
        //Player2 playerScript2 = collision.collider.GetComponent<Player2>();

        //If the player collides with an object or asset(s) that 
        //Have a playerscript attached to it
        if (playerScript)
        {


            scoreObject.scoreValue += 50;
            // Destroy the gameObject that this script is attracted to
            // (the scrolls) 

            Destroy(gameObject);
        }
    }
}

