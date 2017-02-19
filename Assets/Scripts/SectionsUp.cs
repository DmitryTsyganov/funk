using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class SectionsUp : MonoBehaviour
{
    public SectionButton[] buttons;

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

    private LoadGame loadGame;

    void Start()
    {
        loadGame = new LoadGame();
        setLanguage();
        ActivateButtons();
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
		    loadGame.LoadScene(2);
		} else
		{
		    loadGame.LoadScene(3);
		}
	}

    private void ActivateButtons()
    {
        for (int i = 1; i < buttons.Length; ++i)
        {
            if (ScenesParameters.Devmode || Saver.isSectionComplete(buttons[i-1].name))
            {
                buttons[i].button.transform.Find("LockImage").gameObject.SetActive(false);
                buttons[i].button.GetComponent<Button>().interactable = true;
            }
        }
    }

    [Serializable]
    public struct SectionButton
    {
        public GameObject button;
        public string name;
    }
}
