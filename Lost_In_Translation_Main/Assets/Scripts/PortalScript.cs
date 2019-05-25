using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// extra using statemet to allow us to use scene management functions
using UnityEngine.SceneManagement;
public class PortalScript : MonoBehaviour {
    
    //designer variables
    //for the scoreobject
    public GameObject scoreObject;

    //and the score script
    public Score saveScore;

    //this is for the tagged gm for setting postion
    private GameMaster gm;

    //player position
    private Player playerPosition;

    //for forcing score to save
    private int takeScore;
 
    //the scene we are loading in to 
    public string sceneToLoad;

    public void Start()
    {
        //sets the score to save on collision with objects tagged with gm 
        saveScore = scoreObject.GetComponent<Score>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        //this sets the position for th enext level
        gm.lastCheckPointPos = new Vector3(-8.19f, 1.394f, 1f);

        //checks the playerscript has been collided with
        Player playerScript = collision.collider.GetComponent<Player>();

        // something only happens when the play is hit
        if (playerScript != null)
        {
            // saving the score forcably between levels
            takeScore = saveScore.scoreValue;
            PlayerPrefs.SetInt("carryscore", takeScore );
            PlayerPrefs.Save();

            //save score 
            saveScore.SaveScore();

            //the next scene we are going to load
            SceneManager.LoadScene(sceneToLoad);


           
        }

    }
}