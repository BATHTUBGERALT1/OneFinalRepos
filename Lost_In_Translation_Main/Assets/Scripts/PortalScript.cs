using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// extra using statemet to allow us to use scene management functions
using UnityEngine.SceneManagement;
public class PortalScript : MonoBehaviour {

    public GameObject scoreObject;

    public Score saveScore;

    private GameMaster gm;

    private Player playerPosition;

    private int takeScore;
  


    public string sceneToLoad;

    public void Start()
    {
        saveScore = scoreObject.GetComponent<Score>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {


        gm.lastCheckPointPos = new Vector3(-8.19f, 1.394f, 1f);
        //checks the playerscript has been collided with
        Player playerScript = collision.collider.GetComponent<Player>();

        // something only happens when the play is hit
        if (playerScript != null)
        {
            // we DID hit the player !!!!!!
            takeScore = saveScore.scoreValue;
            PlayerPrefs.SetInt("carryscore", takeScore );
            PlayerPrefs.Save();

            saveScore.SaveScore();


            SceneManager.LoadScene(sceneToLoad);


           
        }

    }
}