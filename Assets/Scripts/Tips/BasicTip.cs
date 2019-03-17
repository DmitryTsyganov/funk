using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BasicTip : MonoBehaviour
{
	public GameObject NextTip;
	public GameObject TipText;
	public String TipName;

	protected bool ReadyToProceed = false;

	protected void SetLanguage()
	{
		// Hack: we need to get localized string based on tip name,
		// but Language stores strings as members. To access them by
		// dynamically determined member name we have to use reflection
		if (TipText != null)
		{
			var localizedTip = typeof(Language)
				.GetField(TipName).GetValue(LanguageManager.getLanguage()).ToString();
			LanguageManager.setText(TipText, localizedTip);
		}
	}

	protected void ProceedIfReady()
	{
		if (!ReadyToProceed)
			return;

		if (NextTip != null)
		{
			NextTip.SetActive(true);
		}
		else
		{
			FinalizeTips();
		}
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		ProceedIfReady();
	}

	void FinalizeTips()
	{
		GameObject.Find("WhiteImage").SetActive(false);
		if (Saver.hasShownTraining() != 1)
			Saver.dontShowTraining();
	}
}
