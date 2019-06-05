using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.SceneManagement;
using Spine;
using UnityEngine.UI;

public class GrapeWalkingAnim : StateMachineBehaviour {

      Animator LoadingAnimator;
	  public string animationName;
	  public float speed=1;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		LoadingAnimator = GameObject.FindGameObjectWithTag ("LoadingText").GetComponent<Animator> ();
		SkeletonAnimation anim = animator.GetComponent<SkeletonAnimation>() ;
		int y = Random.Range (0,7);
		if(  y==0  )
		{
			animationName = "Apple";
		}
		if(y==1)
		{
			

			animationName = "Pomegranate";
		}
		if(y==2)
		{
			animationName = "Strawberry";
		}
        if (y == 3)
        {
            animationName = "Pear";
        }
        if (y == 4)
        {
            animationName = "Papaya";
        }
        if (y == 5)
        {
            animationName = "Papaya";
        }
        if (y == 6)
        {
            animationName = "Kiwi";
        }
        if (y == 7)
        {
            animationName = "Grapes";
        }

        anim.state.SetAnimation (0,animationName, true).timeScale = speed ;
		float x = anim.state.GetCurrent (0).AnimationEnd;
		Debug.Log (x.ToString ());

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}


	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		SkeletonAnimation anim = animator.GetComponent<SkeletonAnimation>() ;
		anim.state.TimeScale = 0;

		Debug.Log ("ShowLevelNow");


		for (int i = 0; i < animator.gameObject.GetComponent<CanvasElementsReference> ().ElementsToSetActive.Length; i++) 
		
		{
			//animator.gameObject.GetComponent<CanvasElementsReference> ().ElementsToSetActive [i].SetActive (true);
		}

		LoadingAnimator.SetTrigger ("Loaded");
		Destroy (animator.gameObject);

	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
