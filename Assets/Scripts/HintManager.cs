using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintManager : MonoBehaviour {
    
    public Text hintText;
    public GameObject hintWindow;
    public GameObject watchAdButton;

    // Use this for initialization
    void Start () {
        watchAdButton.SetActive(false);
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
            getHint();
        }
    }

    public void watchAdForHint()
    {
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
