using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour {

   
    private GameMaster gm;
    public int LastScore;



    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LastScore = PlayerPrefs.GetInt("score", 0);

            PlayerPrefs.SetInt("CheckScore", LastScore);
            PlayerPrefs.Save();

            gm.lastCheckPointPos = transform.position;

            PlayerPrefs.SetInt("CheckPointHit", 1);
            PlayerPrefs.Save();

        
        }
    }

  
}
