using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinScale : StateMachineBehaviour
{
    public float speed;
    float size;
    public float shrinkSize;

    Transform transform;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = animator.gameObject.transform;
        size = transform.localScale.x;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        Vector3 scale = transform.localScale;
        //calculate what the new Y position will be
        float newSize = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.localScale = new Vector3((newSize * shrinkSize) + size, scale.y, (newSize * shrinkSize) + size);
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
