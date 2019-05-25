using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvWalls : MonoBehaviour {

    //the position of the wall
    private Vector3 StartingPosition;

    private Animator myAnimator;

    // Use this for initialization
    void Start()
    {
        //send it back to the start 
        StartingPosition = transform.position;


    }

    // Update is called once per frame
    void Update()
    {

    }

    //when called it resets position on player death
    public void ResetSelf()
    {
        myAnimator = GetComponent<Animator>();
        if (myAnimator != null)
        {
            //myAnimator.Play("InvWalls (16)", -1, 0f);
            myAnimator.SetBool("MovingInvWalls", false);

        }
        transform.position = StartingPosition;
    }


}