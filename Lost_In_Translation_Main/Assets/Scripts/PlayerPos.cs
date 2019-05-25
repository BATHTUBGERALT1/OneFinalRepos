using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour {

    //variables for player position
    public int ScoreToSet;

    private GameMaster gm;

    public GameObject[] Boulders;
    // Use this for initialization

    void Start () {
        //boulder positions
        Boulders = GameObject.FindGameObjectsWithTag("Other");

        //saves the score dependent on player position
        ScoreToSet = PlayerPrefs.GetInt("CheckScore", 0);
        PlayerPrefs.SetInt("score", ScoreToSet);
        PlayerPrefs.Save();

        //resets the boulder position 
        foreach (GameObject Boulder in Boulders)
        {
            
            Boulder.GetComponent<Boulder_Script>().ResetSelf();
        }

        //for the player position with checkpoints
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
