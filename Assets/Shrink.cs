using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : StateMachineBehaviour
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
        animator.SetBool("Expanding", false);
        animator.SetBool("Shrinking", true);
        gameObject = animator.gameObject;
        animationHelper = gameObject.GetComponent<AnimationHelper>();
        currentScaleSpeed = scaleSpeed;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animationHelper.currentSize.x > 0f || animationHelper.currentSize.y > 0f || animationHelper.currentSize.z > 0f)
        {
            animationHelper.currentRotationSpeed += new Vector3(rotationAcceleration, rotationAcceleration, rotationAcceleration) * Time.deltaTime;
            animationHelper.currentSize -= new Vector3(currentScaleSpeed, currentScaleSpeed, currentScaleSpeed) * Time.deltaTime;
            currentScaleSpeed += scaleAcceleration * Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            animationHelper.currentSize = Vector3.zero;
            animationHelper.currentRotationSpeed = Vector3.zero;
            gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
            animator.SetBool("Shrinking", false);
            animator.SetBool("Shrunk", true);
        }
    }
}