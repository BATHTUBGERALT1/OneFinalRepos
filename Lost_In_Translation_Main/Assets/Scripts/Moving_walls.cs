using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_walls : MonoBehaviour {

    [SerializeField] private Animator invWallsController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            invWallsController.SetBool("MovingInvWalls", true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            invWallsController.SetBool("MovingInvWalls", false);
    }

}
