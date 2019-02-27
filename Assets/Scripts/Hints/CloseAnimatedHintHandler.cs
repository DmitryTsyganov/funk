using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAnimatedHintHandler : MonoBehaviour {

    public AnimatedHintsHandler Parent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
	    Parent.StartClosingAnimation();
        //Destroy(Parent);
    }
}
