﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : StateMachineBehaviour
{
    public Vector3 speed = new Vector3(1f, 1f, 1f);
    public bool ignoreX = false;
    public bool ignoreY = false;
    public bool ignoreZ = false;

    Rotator rotator;
    GameObject gameObject;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameObject = animator.gameObject;
        rotator = gameObject.GetComponent<Rotator>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!AnimationHelper.CheckRotation(rotator, speed, ignoreX, ignoreY, ignoreZ))
        {
            AnimationHelper.AccelerateRotationTowards(rotator, speed, 1f, ignoreX, ignoreY, ignoreZ);
        }
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
