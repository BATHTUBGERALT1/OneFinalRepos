using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_walls : MonoBehaviour {
    //this allows the variable to be shown in inspector
    [SerializeField] private Animator invWallsController;

    //this is for the position of the walls, if the triggers hit it moves, if not it stays in pos
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
