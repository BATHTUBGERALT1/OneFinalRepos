using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour {
    public int ScoreToSet;
    private GameMaster gm;
    // Use this for initialization
    void Start () {

      
        ScoreToSet = PlayerPrefs.GetInt("CheckScore", 0);
        PlayerPrefs.SetInt("score", ScoreToSet);
        PlayerPrefs.Save();

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
