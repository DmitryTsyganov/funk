using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTipHandler : MonoBehaviour
{
	private Animator KeyboardAnimator;
	// Use this for initialization
	void Start () {
		KeyboardAnimator = GameObject.Find("Keyboard").GetComponent<Animator>();
		Debug.Log("start keyboard helper log");
		Debug.Log(KeyboardAnimator == null);
	}

	public void Click()
	{
		KeyboardAnimator.SetBool("Open", true);
		Debug.Log("start keyboard helper CLICK");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
