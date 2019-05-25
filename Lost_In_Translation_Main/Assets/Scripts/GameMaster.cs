using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    //creates the gamemaster and the last checkpoint variables
    private static GameMaster instance;
    public Vector2 lastCheckPointPos;
    

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

        } else {
            Destroy(gameObject);
        }
    }
}
