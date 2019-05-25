using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_Script : MonoBehaviour {

    //variables 
    private Vector3 StartingPosition;

    private Animator myAnimator; 

    // Use this for initialization
    void Start () {
        StartingPosition = transform.position;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //resets the position of the boulders with the animators facing both right and left
    public void ResetSelf()
    {
        myAnimator = GetComponent<Animator>();
        if (myAnimator != null){
            myAnimator.Play("Boulder 1", -1, 0f);
            myAnimator.Play("Boulder 2 (1)", -1, 0f);
        }
        transform.position = StartingPosition;
    }

    
}
