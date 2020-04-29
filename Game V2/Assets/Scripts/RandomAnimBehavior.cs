using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimBehavior : StateMachineBehaviour
{
    readonly float tailMinTime = 1;
    readonly private float tailMaxTime = 3;

    private float tailTimer = 0;

    private string[] tailTriggers = {"TailWag"};
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (tailTimer <= 0)
        {
            TailWagRandom(animator);
            tailTimer = Random.Range(tailMinTime, tailMaxTime);
        }
       // else
        //{
            tailTimer -= Time.deltaTime;
        //}
    }

    void TailWagRandom(Animator animator)
    {
        System.Random rnd = new System.Random();
        int tailWagTime = rnd.Next(tailTriggers.Length);
        string tailTrigger = tailTriggers[tailWagTime];
        animator.SetTrigger(tailTrigger);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
