using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimatedHintAnimationStop : StateMachineBehaviour
{
	private AnimatedHintsHandler animatedHintHandler;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// TODO: store reference somehow?
		animatedHintHandler = FindObjectOfType<AnimatedHintsHandler>();
		animatedHintHandler.Close();
	}
}
