using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : StateMachineBehaviour
{
    public float scaleSpeed = 1f;
    public float scaleAcceleration = 10f;
    public float rotationAcceleration = 10f;
    public bool lockXScale = false;
    public bool lockYScale = false;
    public bool lockZScale = false;
    public bool lockXRotation = false;
    public bool lockYRotation = false;
    public bool lockZRotation = false;

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
        if(animationHelper.IsRotatingTooSlowly(animationHelper.rotationSpeed, lockXRotation, lockYRotation, lockZRotation))
        {
            animationHelper.AccelerateRotationTowardsTarget(rotationAcceleration, lockXRotation, lockYRotation, lockZRotation);
        }
        else
        {
            animationHelper.currentRotationSpeed = animationHelper.rotationSpeed;
        }

        if(animationHelper.IsTooSmall(animationHelper.size, lockXScale, lockYScale, lockZScale))
        {
            animationHelper.ScaleTowardsTarget(currentScaleSpeed, lockXScale, lockYScale, lockZScale);
            currentScaleSpeed += scaleAcceleration;
        }
        else
        {
            animationHelper.currentSize = animationHelper.size;
        }

        if(!animationHelper.IsTooSmall(animationHelper.size, lockXScale, lockYScale, lockZScale) && !animationHelper.IsRotatingTooSlowly(animationHelper.rotationSpeed, lockXRotation, lockYRotation, lockZRotation))
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
