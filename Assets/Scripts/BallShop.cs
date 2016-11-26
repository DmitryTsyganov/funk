using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallShop : MonoBehaviour
{

    public static string selectedBall;
    public GameObject content;
    public GameObject ballShopItemPrefab;
    public Text starsCountText;
    public List<Item> ballsToSell = new List<Item>();
    public List<Item> additionalFeatures = new List<Item>();

    public GameObject watchAdText;
    public GameObject backText;
    public GameObject watchAdButton;


    private const int ballShopReward = 40;
    private const string rewardDummy = "{0}";

    private BallShopItemHandler[] ballButtonHandlers;

    // Use this for initialization
    void Start () {
        BallParametrs.start();
        updateStarsCountText();

        int i = 0;
        foreach (var item in ballsToSell)
        {
            var button = createButton(item);
            ballButtonHandlers[i] = button.GetComponent<BallShopItemHandler>();
            ++i;
        }

        foreach (var item in additionalFeatures)
        {
            var button = createButton(item);
            transformButton(button);
        }

        setLanguage();

        watchAdButton.SetActive(false);
    }

    private GameObject createButton(Item item)
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
        handler.basicShopItemStart();
        handler.Name = item.obj.name;
        handler.ObjNameText.text = item.objName;
        return button;
    }

    private void transformButton(GameObject button)
    {
        var oldhandler = button.GetComponent<BallShopItemHandler>();
        var newHandler = button.AddComponent<AddonShopItemHandler>();

        newHandler.Name = oldhandler.Name;
        newHandler.price = oldhandler.price;
        newHandler.PriceText = oldhandler.PriceText;
        newHandler.lockImage = oldhandler.lockImage;
        newHandler.ObjNameText = oldhandler.ObjNameText;
        newHandler.StarImage = oldhandler.StarImage;
        newHandler.ballImage = oldhandler.ballImage;

        button.GetComponent<Button>().onClick.AddListener(delegate {newHandler.Click();});

        newHandler.basicShopItemStart();
        Destroy(oldhandler);
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
    }

    public void getRandomBallForFree()
    {
        BallShopItemHandler[] handlersToBuy = {};
        int i = 0;
        foreach (var handler in ballButtonHandlers)
        {
            if (!handler.isBought())
            {
                handlersToBuy[i] = handler;
                ++i;
            }
        }

        handlersToBuy[Mathf.RoundToInt(UnityEngine.Random.value*handlersToBuy.Length -1)].getForFree();
    }

    private void addStars()
    {
        Shop.StarScore += ballShopReward;
        updateStarsCountText();
    }

    private void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText(backText, LanguageManager.getLanguage().back);
        LanguageManager.setText(watchAdText, LanguageManager.getLanguage()
            .watch_ad_shop.Replace(rewardDummy, ballShopReward.ToString()));

        /*foreach (var o in GameObject.FindGameObjectsWithTag("BuyText"))
        {
            LanguageManager.setText(o, LanguageManager.getLanguage().buy);
        }*/
    }
    
    [Serializable]
    public class Item
    {
        public string objName;
        public GameObject obj;
        public int price;
    }
}
