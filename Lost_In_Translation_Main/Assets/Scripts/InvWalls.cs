using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvWalls : MonoBehaviour {
    private Vector3 StartingPosition;

    private Animator myAnimator;

    // Use this for initialization
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ResetSelf()
    {
        myAnimator = GetComponent<Animator>();
        if (myAnimator != null)
        {
            myAnimator.Play("InvWalls (16)", -1, 0f);
            myAnimator.SetBool("MovingInvWalls", false);

        }
    
    }


}