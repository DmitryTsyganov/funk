using System;
using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;
using System.IO;

public class StarScoreText : MonoBehaviour {

	public Text ScoreStartText;

    void Start()
    {
        //RewardedVideoGoogleAdmobManager.GetInstance();
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText("ThanksText", LanguageManager.getLanguage().thanks);
    }

	void Update () {
        ScoreStartText.text = Shop.StarScore.ToString();
    }
}
