using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtonHandler : MonoBehaviour
{

	public GameObject ResetText;

	// Use this for initialization
	void Start () {
		setLanguage();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setLanguage()
	{
		LanguageManager.setLanguageIfNotAlready();
		LanguageManager.setText(ResetText, LanguageManager.getLanguage().reset);
	}
}
