using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrEggmanBoss : MonoBehaviour
{
    public bool gotHit = false;
    public Sprite MadDrEggman;
    public Boss boss;

    public void setMadSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = MadDrEggman;
        boss = GetComponentInParent<Boss>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "PlayerBullet" && !boss.canBeHit)
        {
            gotHit = true;
            GetComponentInParent<Boss>().DamageBoss(100);
        }
    }
}
