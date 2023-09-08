using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleBehavior : StateMachineBehaviour
{
    [SerializeField] private float timeUntilSwitch;
    [SerializeField] private float animationRange;

    private bool isTriggered;
    private float idleTime;
    private float trigerredAnimation;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       ResetIdle();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(isTriggered == false) {
           idleTime += Time.deltaTime;
           if(idleTime > timeUntilSwitch && stateInfo.normalizedTime % 1 < 0.02f) {
            isTriggered = true;
            trigerredAnimation = Random.Range(0f, animationRange);

            animator.SetFloat("IdleAnimation", trigerredAnimation);
           }
       }
       else if (stateInfo.normalizedTime % 1 > 0.98) {
        ResetIdle();
       }

       animator.SetFloat("IdleAnimation", trigerredAnimation, 0.2f, Time.deltaTime);

    }

    private void ResetIdle() {
        // if(isTriggered) {
        //     trigerredAnimation--;
        // }

        isTriggered = false;
        idleTime = 0;
    }
}
