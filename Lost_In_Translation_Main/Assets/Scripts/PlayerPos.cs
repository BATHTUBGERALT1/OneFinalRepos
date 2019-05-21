using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour {
    public int ScoreToSet;
    private GameMaster gm;

    public GameObject[] Boulders;
    // Use this for initialization
    void Start () {
        Boulders = GameObject.FindGameObjectsWithTag("Other");

        ScoreToSet = PlayerPrefs.GetInt("CheckScore", 0);
        PlayerPrefs.SetInt("score", ScoreToSet);
        PlayerPrefs.Save();

        foreach (GameObject Boulder in Boulders)
        {
            print("hello");
            Boulder.GetComponent<Boulder_Script>().ResetSelf();
        }

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
