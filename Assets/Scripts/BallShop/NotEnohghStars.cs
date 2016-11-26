using UnityEngine;
using System.Collections;

public class NotEnohghStars : MonoBehaviour
{
    public GameObject watchAdText;
    public GameObject backText;
    public GameObject watchAdButton;
    public GameObject PromptText;

    private BallShop ballshop;

    private const string rewardDummy = "{0}";

    // Use this for initialization
    void Start ()
    {
        setLanguage();
        watchAdButton.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (RewardedVideoUnityAdsManager.GetInstance().isAdReady()) watchAdButton.SetActive(true);
    }

    public void Back()
    {
        Destroy(gameObject);
    }

    private void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText(PromptText, LanguageManager.getLanguage().not_enough_stars);
        LanguageManager.setText(backText, LanguageManager.getLanguage().back);
        LanguageManager.setText(watchAdText, LanguageManager.getLanguage()
            .watch_ad_shop.Replace(rewardDummy, BallShop.ballShopReward.ToString()));
    }

    public void WatchAd()
    {
        ballshop = GameObject.Find("Canvas").GetComponent<BallShop>();
        ballshop.watchAdForStars();
        Destroy(gameObject);
    }
}
