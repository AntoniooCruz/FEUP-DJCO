using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_BlastShooting : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;

    float timeToFire = 0;
    BossWeapon weapon;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        weapon = animator.GetComponent<BossWeapon>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("Idle");
            return;
        }
        else
        {
            timer -= Time.fixedDeltaTime;

        }

        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / weapon.powerShot_FireRate;
            weapon.PowerShot();

        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
    }
}
