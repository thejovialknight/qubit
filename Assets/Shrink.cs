using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : StateMachineBehaviour
{
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
        animator.SetBool("Expanding", false);
        animator.SetBool("Shrinking", true);
        gameObject = animator.gameObject;
        rotator = gameObject.GetComponent<Rotator>();
        currentScaleSpeed = 0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!AnimationHelper.CheckSize(gameObject.transform, Vector3.zero, lockXScale, lockYScale, lockZScale))
        {
            AnimationHelper.AccelerateRotationTowards(rotator, new Vector3(500f, 500f, 500f), rotationAcceleration, lockXRotation, lockYRotation, lockZRotation);
            AnimationHelper.ScaleTowards(gameObject.transform, Vector3.zero, currentScaleSpeed, lockXScale, lockYScale, lockZScale);
            currentScaleSpeed += scaleAcceleration * Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.localScale = Vector3.zero;
            rotator.speed = Vector3.zero;
            gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
            animator.SetBool("Shrinking", false);
            animator.SetBool("Shrunk", true);
        }
    }
}