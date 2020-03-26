using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ArmIdle : StateMachineBehaviour
{
    private int rand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetComponentInParent<Boss>().canBeHit)
            return;
            
        if (rand == 0)
        {
            animator.SetTrigger("RegularShooting");
        }
        else
        {
            animator.SetTrigger("BlastShooting");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("BlastShooting");
        animator.ResetTrigger("RegularShooting");

    }


}
