using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class SectionsUp : MonoBehaviour
{

    public GameObject LinearText;
    public GameObject PowerText;
    public GameObject RootText;
    public GameObject LogarithmText;
    public GameObject ExponentalText;
    public GameObject TrigonometricText;
    public GameObject PolinomialText;
    public GameObject HyperbolicText;
    public GameObject MixedText;
    public GameObject SpecialText;
    public GameObject BottomMenuButtonText;

    void Start()
    {
        setLanguage();
    }

    void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText(LinearText, LanguageManager.getLanguage().linear);
        LanguageManager.setText(PowerText, LanguageManager.getLanguage().power);
        LanguageManager.setText(RootText, LanguageManager.getLanguage().root);
        LanguageManager.setText(LogarithmText, LanguageManager.getLanguage().logarithm);
        LanguageManager.setText(ExponentalText, LanguageManager.getLanguage().exponental);
        LanguageManager.setText(TrigonometricText, LanguageManager.getLanguage().trigonometric);
        LanguageManager.setText(PolinomialText, LanguageManager.getLanguage().polinomial);
        LanguageManager.setText(HyperbolicText, LanguageManager.getLanguage().hyperbolic);
        LanguageManager.setText(MixedText, LanguageManager.getLanguage().mixed);
        LanguageManager.setText(SpecialText, LanguageManager.getLanguage().special);
        LanguageManager.setText(BottomMenuButtonText, LanguageManager.getLanguage().main_screen);

        GameObject[] objs = GameObject.FindGameObjectsWithTag("ComingSoon");
        foreach (GameObject obj in objs)
        {
            LanguageManager.setText(obj, LanguageManager.getLanguage().coming_soon);
        }
    }

    public void SelectSection(string sectionName){
		
		ScenesParameters.Section = sectionName;
		TextAsset text = Resources.Load(ScenesParameters.LevelsDirectory + '/'
			+ ScenesParameters.Section + '/' + "config") as TextAsset;

		ScenesParameters.LevelsNumber = Int32.Parse(text.text);
		if (!ScenesParameters.Devmode)
		{
			Application.LoadLevel(2);
		} else
		{
			Application.LoadLevel(3);
		}
	}
}
