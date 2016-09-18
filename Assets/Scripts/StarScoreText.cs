using System;
using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;
using System.IO;
using GoogleMobileAds.Api;

public class StarScoreText : MonoBehaviour {

	public Text ScoreStartText;
	public Text hintText;
	public GameObject hintWindow;

    void Start()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText("ThanksText", LanguageManager.getLanguage().thanks);
        // Get singleton reward based video ad reference.
        
    }

	void Update () {
        ScoreStartText.text = Shop.StarScore.ToString();
    }

	public void AddHint(){
		if (Shop.BuyHint()) {
		    buyHint();
        }
    }

    private void buyHint()
    {
        hintText.text = ScenesParameters.trueFunction;
        hintWindow.SetActive(true);
        Saver.saveHint();
        ScoreStartText.text = Shop.StarScore.ToString();
    }
}
