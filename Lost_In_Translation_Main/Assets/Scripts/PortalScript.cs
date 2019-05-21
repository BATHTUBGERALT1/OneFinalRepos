using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// extra using statemet to allow us to use scene management functions
using UnityEngine.SceneManagement;
public class PortalScript : MonoBehaviour {

    public Score scoreObject;

    private GameMaster gm;

    private Player playerPosition;
    

    public string sceneToLoad;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        gm.lastCheckPointPos = new Vector3(-8.282f, -3.2f, 1f);
        //checks the playerscript has been collided with
        Player playerScript = collision.collider.GetComponent<Player>();

        // something only happens when the play is hit
        if (playerScript != null)
        {
            // we DID hit the player !!!!!!


            scoreObject.SaveScore();
      
        
            SceneManager.LoadScene(sceneToLoad);
           

        }

    }
}