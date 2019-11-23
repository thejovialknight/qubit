using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : StateMachineBehaviour
{
    Vector3 size;
    public Vector3 rotationSpeed;
    public float scaleAcceleration = 10f;
    public float rotationAcceleration = 10f;
    public bool lockXScale = false;
    public bool lockYScale = false;
    public bool lockZScale = false;
    public bool lockXRotation = false;
    public bool lockYRotation = false;
    public bool lockZRotation = false;

    float currentScaleSpeed;

    Rotator rotator;
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
        rotator = gameObject.GetComponent<Rotator>();
        currentScaleSpeed = 0f;
        size = new Vector3(animator.GetFloat("xScale"), animator.GetFloat("yScale"), animator.GetFloat("zScale"));
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!AnimationHelper.CheckRotation(rotator, rotationSpeed, lockXRotation, lockYRotation, lockZRotation))
        {
            AnimationHelper.AccelerateRotationTowards(rotator, rotationSpeed, rotationAcceleration, lockXRotation, lockYRotation, lockZRotation);
        }
        else
        {
            rotator.speed = rotationSpeed;
        }

        if(!AnimationHelper.CheckSize(gameObject.transform, size, lockXScale, lockYScale, lockZScale))
        {
            AnimationHelper.ScaleTowards(gameObject.transform, size, currentScaleSpeed, lockXScale, lockYScale, lockZScale);
            currentScaleSpeed += scaleAcceleration;
        }
        else
        {
            gameObject.transform.localScale = size;
        }

        if(AnimationHelper.CheckSize(gameObject.transform, size, lockXScale, lockYScale, lockZScale) 
            && AnimationHelper.CheckRotation(rotator, rotationSpeed, lockXRotation, lockYRotation, lockZRotation))
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
