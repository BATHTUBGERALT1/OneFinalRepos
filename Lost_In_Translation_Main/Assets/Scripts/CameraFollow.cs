using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //follows the player
    public Transform followTarget;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //follows the player
        if (followTarget != null)
        {
            Vector3 newPosition = followTarget.position;
            newPosition.z = transform.position.z;
            transform.position = newPosition;

        }
    }
}