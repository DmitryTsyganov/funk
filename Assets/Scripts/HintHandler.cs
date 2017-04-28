using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class HintHandler : InternetDependantHandler {

    public Text hintText;
    public GameObject hintWindow;

	// Use this for initialization
	void Start () {
	    DoStart();
		OnClick += delegate(object sender, EventArgs args) { watchAdForHint(); };
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void watchAdForHint()
    {

        Analytics.CustomEvent(AnalyticsParameters.HintBought,
            new Dictionary<string, object> {
                {"payment_type", "ad"},
                {"section", ScenesParameters.Section},
                {"level", ScenesParameters.CurrentLevel}});
        //RewardedVideoGoogleAdmobManager.GetInstance().watchAdForHint();
        RewardedVideoUnityAdsManager.GetInstance().ShowRewardedAd(getHint);
    }

    private void getHint()
    {
        hintText.text = ScenesParameters.trueFunction;
        hintWindow.SetActive(true);
        Saver.saveHint();
    }
}
