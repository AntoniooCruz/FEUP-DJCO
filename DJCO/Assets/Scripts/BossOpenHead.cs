using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOpenHead : StateMachineBehaviour
{
    Boss Boss;
    DrEggmanBoss eggmanBoss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss = animator.GetComponent<Boss>();
        eggmanBoss = animator.GetComponentInChildren<DrEggmanBoss>();
        Boss.canBeHit = false;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (eggmanBoss.gotHit) {
            if (Boss.stats.Health <= Boss.maxHeath / 2){
                animator.SetTrigger("GetMad");
                
            }
            else
                animator.SetTrigger("CloseHead");

            eggmanBoss.gotHit = false;
        }
    }



    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("CloseHead");

    }


}
