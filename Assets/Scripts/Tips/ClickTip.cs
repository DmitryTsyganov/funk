using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTip : BasicTip {

	public void SetReadyToProceed()
	{
		ReadyToProceed = true;
	}
	// Use this for initialization
	void Start () {
		SetLanguage();
	}
	
	// Update is called once per frame
	void Update () {
		ProceedIfReady();
	}
}
