#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class AnimationChangeTest : MonoBehaviour
{
    public AnimationClip[] animations;

	// Use this for initialization
	void Start ()
	{
	    UnityEditor.Animations.AnimatorController ac = GetComponent<Animator>().runtimeAnimatorController as UnityEditor.Animations.AnimatorController;


        UnityEditor.Animations.AnimatorStateMachine sm = ac.layers[0].stateMachine;

        for (int i = 0; i < sm.states.Length; i++)
        {
            sm.states[i].state.motion = animations[1];
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
#endif
