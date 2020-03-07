using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag ("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Spawner")){
            return;
        }    

        Debug.Log("Tag: " + this.tag + " || " + other);

        if(other.CompareTag ("Player")){
            // TODO: Take HP from the player
        }

        Destroy (other.gameObject);
        Destroy (gameObject);
    }
}
