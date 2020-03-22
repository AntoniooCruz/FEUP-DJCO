using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "EnemyBullet"){
            other.gameObject.SetActive(false);
            return;
        }
        Destroy(other.gameObject);
    }
}
