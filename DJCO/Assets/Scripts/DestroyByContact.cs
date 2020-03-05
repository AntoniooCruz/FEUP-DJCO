using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("Tag: " + this.tag + " || " + other.tag);
        if(other.CompareTag ("Boundary") || other.CompareTag("Enemy")){
            return;
        }    

        if(other.CompareTag ("Player")){
            // TODO: Take HP from the player
        }

        Destroy (other.gameObject);
        Destroy (gameObject);
    }
}
