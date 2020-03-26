using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_MadIdle : StateMachineBehaviour
{

    Boss boss;
    DrEggmanBoss eggmanBoss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        boss.canBeHit = true;
        animator.GetComponentInChildren<BossWeapon>().enraged = true;
        eggmanBoss = animator.GetComponentInChildren<DrEggmanBoss>();
        eggmanBoss.setMadSprite();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}

