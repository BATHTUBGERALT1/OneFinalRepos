using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_Script : MonoBehaviour {
    private Vector3 StartingPosition;

    private Animator myAnimator; 

    // Use this for initialization
    void Start () {
        StartingPosition = transform.position;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
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
