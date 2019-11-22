using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : StateMachineBehaviour
{
    public float scaleSpeed = 1f;
    public float scaleAcceleration = 10f;
    public float rotationAcceleration = 10f;

    float currentScaleSpeed;

    AnimationHelper animationHelper;
    GameObject gameObject;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Expanded", false);
        animator.SetBool("Shrunk", false);
        animator.SetBool("Expanding", true);
        animator.SetBool("Shrinking", false);
        gameObject = animator.gameObject;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        animationHelper = gameObject.GetComponent<AnimationHelper>();
        currentScaleSpeed = scaleSpeed;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animationHelper.IsRotatingTooSlowly())
        {
            animationHelper.AccelerateRotationTowardsTarget(rotationAcceleration);
        }
        else
        {
            animationHelper.currentRotationSpeed = animationHelper.rotationSpeed;
        }

        if(animationHelper.IsTooSmall())
        {
            animationHelper.ScaleTowardsTarget(currentScaleSpeed);
            currentScaleSpeed += scaleAcceleration;
        }
        else
        {
            animationHelper.currentSize = animationHelper.size;
        }

        if(!animationHelper.IsTooSmall() && !animationHelper.IsRotatingTooSlowly())
        {
            animator.SetBool("Expanding", false);
            animator.SetBool("Expanded", true);
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
