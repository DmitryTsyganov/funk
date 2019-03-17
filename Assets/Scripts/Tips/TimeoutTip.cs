using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeoutTip : BasicTip {
	public GameObject TapText;

	private const int ProceedingTimeout = 3;

	private bool timeoutOver = false;
	// Use this for initialization
	void Start () {
		SetLanguage();
		StartCoroutine(WaitBeforeProceeding());
	}
	
	protected new void SetLanguage()
	{
		base.SetLanguage();
		LanguageManager.setText(TapText, LanguageManager.getLanguage().tap_to_continue);
	}
	
	// Update is called once per frame
	void Update () {
		if (timeoutOver && Input.anyKey)
		{
			ReadyToProceed = true;
		}
		ProceedIfReady();
	}

	IEnumerator WaitBeforeProceeding()
	{
		yield return new WaitForSeconds(ProceedingTimeout);
		transform.FindChild("TapImage").gameObject.SetActive(true);
		timeoutOver = true;
		yield return null;
	}
}
