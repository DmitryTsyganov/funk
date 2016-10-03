using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BallShop : MonoBehaviour
{

    public static string selectedBall;
    public GameObject content;
    public GameObject ballShopItemPrefab;
    public Text starsCountText;
    public List<Item> ballsToSell = new List<Item>();

    public GameObject watchAdText;
    public GameObject backText;
    public GameObject watchAdButton;


    private const int ballShopReward = 40;
    private const string rewardDummy = "{0}";

    // Use this for initialization
    void Start () {
        BallParametrs.start();
        updateStarsCountText();

        foreach (var item in ballsToSell)
        {
            var button = Instantiate(ballShopItemPrefab);
            button.transform.parent = content.transform;
            button.transform.localScale = Vector3.one;
            button.GetComponent<Animator>().runtimeAnimatorController =
                item.obj.GetComponent<Animator>().runtimeAnimatorController;
            button.GetComponent<SpriteRenderer>().sprite =
                item.obj.GetComponent<SpriteRenderer>().sprite;
            var handler = button.GetComponent<BallShopItemHandler>();
            handler.price = item.price;
            handler.Name = item.obj.name;
        }
        setLanguage();

        watchAdButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    if (RewardedVideoUnityAdsManager.GetInstance().isAdReady()) watchAdButton.SetActive(true);
	}

    public void updateStarsCountText()
    {
        starsCountText.text = Shop.StarScore.ToString();
    }

    public void watchAdForStars()
    {
        RewardedVideoUnityAdsManager.GetInstance().ShowRewardedAd(addStars);
        updateStarsCountText();
    }

    private void addStars()
    {
        Shop.StarScore += ballShopReward;
    }

    private void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText(backText, LanguageManager.getLanguage().back);
        LanguageManager.setText(watchAdText, LanguageManager.getLanguage()
            .watch_ad_shop.Replace(rewardDummy, ballShopReward.ToString()));

        foreach (var o in GameObject.FindGameObjectsWithTag("BuyText"))
        {
            LanguageManager.setText(o, LanguageManager.getLanguage().buy);
        }
    }
    
    [Serializable]
    public class Item
    {
        public GameObject obj;
        public int price;
    }
}
