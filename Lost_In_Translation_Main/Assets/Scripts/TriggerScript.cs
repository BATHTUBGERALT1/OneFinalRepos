using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    [SerializeField] private Animator boulderController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Other"))
        boulderController.SetBool("StopBoulder", true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Other"))
            boulderController.SetBool("StopBoulder", false);
    }


}
