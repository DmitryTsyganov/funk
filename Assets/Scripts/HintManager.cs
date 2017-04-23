using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class HintManager : MonoBehaviour {
    
    public Text hintText;
    public GameObject hintWindow;
    public GameObject watchAdButton;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (RewardedVideoUnityAdsManager.GetInstance().isAdReady() && 
            !watchAdButton.activeInHierarchy)
        {
            print("Activating watch ad button");
            watchAdButton.SetActive(true);
        }
    }

    public void AddHint()
    {
        if (Shop.BuyHint())
        {
            Analytics.CustomEvent(AnalyticsParameters.HintBought,
                new Dictionary<string, object> {
                    {"payment_type", "stars"},
                    {"section", ScenesParameters.Section},
                    {"level", ScenesParameters.CurrentLevel}});
            getHint();
        }
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
