using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_Script : MonoBehaviour {
    private Vector3 StartingPosition;
    // Use this for initialization
    void Start () {
        StartingPosition = transform.position;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ResetSelf()
    {
        transform.position = StartingPosition;
    }

}
