using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class WatchAdHandler : InternetDependantHandler
{

    public GameObject WatchAdText;

	// Use this for initialization
	void Start ()
	{
	    DoStart();
	    OnClick += delegate(object sender, EventArgs args) { WatchAd(); };
	    setLanguage();
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void WatchAd()
    {
        Analytics.CustomEvent(AnalyticsParameters.AdWatchedInShop);
        var ballshop = GameObject.Find("ShopCanvas").GetComponent<BallShop>();
        ballshop.watchAdForStars();
        //Destroy(gameObject);
    }

    private void setLanguage()
    {
        LanguageManager.setText(WatchAdText, String.Format(LanguageManager.getLanguage()
            .watch_ad_shop, BallShop.ballShopReward));
    }
}
