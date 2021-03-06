﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyStarsHandler : InternetDependantHandler
{
    public GameObject BuyStarsText;

	// Use this for initialization
	void Start () {

	}

    private void OnEnable()
    {
        if (LanguageManager.getLanguage() != null)
        {
            setLanguage();
        }

        DoStart();
        OnClick += delegate(object sender, EventArgs args) { BuyMillionStars(); };
    }

    // Update is called once per frame
	void Update () {
		
	}

    private void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        var language = LanguageManager.getLanguage();
        LanguageManager.setText(BuyStarsText, language.buy + "\n" + Shop.StarsUltimate + "\n" + language.stars);
    }

    public void BuyMillionStars()
    {
        IAPHandler.GetInstance().BuyProduct("million_stars");
    }
}
