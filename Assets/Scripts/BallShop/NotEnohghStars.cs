﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class NotEnohghStars : MonoBehaviour
{
    public GameObject watchAdText;
    public GameObject backText;
    public GameObject watchAdButton;
    public GameObject PromptText;

    private BallShop ballshop;

    // Use this for initialization
    void Start ()
    {
        setLanguage();
        watchAdButton.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        //if (RewardedVideoUnityAdsManager.GetInstance().isAdReady()) watchAdButton.SetActive(true);
    }

    private void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText(PromptText, LanguageManager.getLanguage().not_enough_stars);
        LanguageManager.setText(backText, LanguageManager.getLanguage().back);
        LanguageManager.setText(watchAdText, String.Format(LanguageManager.getLanguage()
                                    .watch_ad_shop, BallShop.ballShopReward));
    }

    public void WatchAd()
    {
        Analytics.CustomEvent(AnalyticsParameters.AdWatchedInShop);
        ballshop = GameObject.Find("ShopCanvas").GetComponent<BallShop>();
        ballshop.watchAdForStars();
        Destroy(gameObject);
    }
}
