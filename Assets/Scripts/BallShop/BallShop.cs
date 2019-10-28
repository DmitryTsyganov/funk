using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallShop : MonoBehaviour
{
    public const int ballShopReward = 30;

    public static string selectedBall;
    public GameObject ContentBalls;
    public GameObject ContentAddons;
    public Image BallsButton;
    public Image AddonsButton;
    public GameObject BallsButtonText;
    public GameObject AddonsButtonText;
    public GameObject AddonsHelpText;
    public GameObject BallMachineHelpText;
    public GameObject ballShopItemPrefab;
    public GameObject BallMachine;
    public GameObject CongratilationsScreen;
    public Image MenuImage;
    public Text starsCountText;
    public List<Item> ballsToSell = new List<Item>();
    public List<Item> additionalFeatures = new List<Item>();
    public int BallsToBuy;
    public BallShopItemHandler currentBall;
                                    
    public delegate void OnSuccess();
    
    private BallShopItemHandler[] ballButtonHandlers;
    private BallShopItemHandler[] effectButtonHandlers;
    private GameObject[] ballButtons;

    private int cheapestBallIndex = 1;

    private static bool doCountBallsToBuy = false;

    // Use this for initialization
    void Awake ()
    {
        BallParametrs.start();

        ballButtonHandlers = new BallShopItemHandler[ballsToSell.Count];
        effectButtonHandlers = new BallShopItemHandler[additionalFeatures.Count];
        ballButtons = new GameObject[ballsToSell.Count];

        Comparison<Item> comparison = delegate(Item item, Item item1)
        {
            if (item.price == item1.price)
                return 0;
            return item.price < item1.price ? -1 : 1;
        };

        ballsToSell.Sort(comparison);
        additionalFeatures.Sort(comparison);

        int i = 0;
        foreach (var item in ballsToSell)
        {
            var button = createButton(item, i, ballButtonHandlers);
            ballButtons[i] = button;
            ++i;
        }

        i = 0;
        foreach (var item in additionalFeatures)
        {
            var button = createButton(item, i, effectButtonHandlers);
            transformButton(button);
            ++i;
        }
        BallsToBuy = countBallsToBuy();

        ActivateAddons();
        ActivateBalls();
    }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            starsCountText = GameObject.Find("StarCountText").GetComponent<Text>();
            updateStarsCountText();
            if (LanguageManager.getLanguage() != null)
            {
                setLanguage();
                //print("Shop language is set");
            }
        }
    }

    private GameObject createButton(Item item, int number, BallShopItemHandler[] handlerArray)
    {
        var buttonWrapper = Instantiate(ballShopItemPrefab);
        var button = buttonWrapper.transform.Find("BallShopItem").gameObject;
        buttonWrapper.transform.SetParent(ContentBalls.transform);
        buttonWrapper.transform.localScale = Vector3.one;
        button.GetComponent<Animator>().runtimeAnimatorController =
            item.obj.GetComponent<Animator>().runtimeAnimatorController;
        button.GetComponent<SpriteRenderer>().sprite =
            item.obj.GetComponent<SpriteRenderer>().sprite;
        var handler = button.GetComponent<BallShopItemHandler>();
        handler.price = item.price;
        handler.basicShopItemStart();
        handler.Name = item.obj.name;
        handlerArray[number] = handler;

        return buttonWrapper;
    }

    private void transformButton(GameObject buttonWrapper)
    {
        var button = buttonWrapper.transform.Find("BallShopItem").gameObject;
        buttonWrapper.transform.SetParent(ContentAddons.transform);
        var oldhandler = button.GetComponent<BallShopItemHandler>();
        var newHandler = button.AddComponent<AddonShopItemHandler>();

        newHandler.Name = oldhandler.Name;
        newHandler.price = oldhandler.price;
        newHandler.PriceText = oldhandler.PriceText;
        newHandler.lockImage = oldhandler.lockImage;
        newHandler.ObjNameText = oldhandler.ObjNameText;
        newHandler.StarImage = oldhandler.StarImage;
        newHandler.ballImage = oldhandler.ballImage;
        newHandler.NotEnoughStars = oldhandler.NotEnoughStars;

        button.GetComponent<Button>().onClick.AddListener(delegate {newHandler.Click();});

        newHandler.basicShopItemStart();
        Destroy(oldhandler);
    }

	// Update is called once per frame
	void Update () {
	    if (doCountBallsToBuy)
	    {
	        countBallsToBuy();
	        doCountBallsToBuy = false;
	    }
	}

    public static void CountBallsToBuy()
    {
        doCountBallsToBuy = true;
    }

    public bool CanBuyCheapestBall()
    {
        return ballsToSell[cheapestBallIndex].price <= Shop.StarScore;
    }

    public GameObject GetCheapestBall()
    {
        return ballButtons[cheapestBallIndex];
    }

    public void updateStarsCountText()
    {
        starsCountText.text = Shop.StarScore.ToString();
    }

    public void watchAdForStars(OnSuccess callback = null)
    {
        if (callback != null)
        {
            RewardedVideoUnityAdsManager.GetInstance().ShowRewardedAd(() =>
            {
                addStars();
                callback();
            });
        }
        else
        {
            RewardedVideoUnityAdsManager.GetInstance().ShowRewardedAd(addStars);
        }
    }

    public void getRandomBallForFree()
    {
        List<BallShopItemHandler> handlersToBuy = new List<BallShopItemHandler>();
        List<GameObject> buttonsToBuy = new List<GameObject>();
        for (int i =0; i < ballButtonHandlers.Length; ++i)
        {
            if (!ballButtonHandlers[i].isBought())
            {
                handlersToBuy.Add(ballButtonHandlers[i]);
                buttonsToBuy.Add(ballButtons[i]);
            }
        }
        int index = UnityEngine.Random.Range(0, handlersToBuy.Count);
        //print("index "+index);
        //print("lenght "+ handlersToBuy.Count);
        handlersToBuy[index].getForFree();
        BallsToBuy = countBallsToBuy();
        var screen = Instantiate(CongratilationsScreen);
        screen.GetComponent<CongratilationsScreen>().AddButton(buttonsToBuy[index]);
    }

    public int countBallsToBuy()
    {
        List<BallShopItemHandler> handlersToBuy = new List<BallShopItemHandler>();
        foreach (var handler in ballButtonHandlers)
        {
            if (!handler.isBought())
            {
                handlersToBuy.Add(handler);
            }
        }
        return handlersToBuy.Count;
    }

    public void ActivateBalls()
    {
        if (AddonsHelpText.activeSelf)
        {
            BallsButton.gameObject.transform.SetSiblingIndex(BallsButton.gameObject.transform.GetSiblingIndex() + 1);
            //AddonsButton.gameObject.transform.SetSiblingIndex(AddonsButton.gameObject.transform.GetSiblingIndex() - 1);
            BallsButton.color = Color.white;
            AddonsButton.color = Color.grey;
            ContentBalls.SetActive(true);
            ContentAddons.SetActive(false);
            AddonsHelpText.SetActive(false);
            if (BallsToBuy != 0)
            {
                BallMachine.SetActive(true);
                BallMachineHelpText.SetActive(true);
            }

            //MenuImage.transform.localScale = MenuImage.transform.localScale + new Vector3(0, 0.5f, 0);
        }
    }

    public void ActivateAddons()
    {
        if (!AddonsHelpText.activeSelf)
        {
            BallsButton.gameObject.transform.SetSiblingIndex(BallsButton.gameObject.transform.GetSiblingIndex() - 1);
            //AddonsButton.gameObject.transform.SetSiblingIndex(AddonsButton.gameObject.transform.GetSiblingIndex() + 1);
            BallsButton.color = Color.grey;
            AddonsButton.color = Color.white;
            ContentBalls.SetActive(false);
            ContentAddons.SetActive(true);
            BallMachineHelpText.SetActive(false);
            AddonsHelpText.SetActive(true);
            if (BallMachine != null)
                BallMachine.SetActive(false);
            //MenuImage.transform.localScale = MenuImage.transform.localScale - new Vector3(0, 0.5f, 0);
        }
    }

    private void addStars()
    {
        Shop.StarScore += ballShopReward;
        updateStarsCountText();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Canvas.ForceUpdateCanvases();
        //SceneView.RepaintAll();
    }

    private void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText(BallsButtonText, LanguageManager.getLanguage().balls);
        LanguageManager.setText(AddonsButtonText, LanguageManager.getLanguage().addons);
        LanguageManager.setText(AddonsHelpText, LanguageManager.getLanguage().addons_help);

        for (int i = 0; i < ballsToSell.Count; ++i)
        {
            ballButtonHandlers[i].ObjNameText.text =
                LanguageManager.getLanguageDynamic()[ballsToSell[i].obj.name].str;
        }

        for (int i = 0; i < additionalFeatures.Count; ++i)
        {
            effectButtonHandlers[i].ObjNameText.text =
                LanguageManager.getLanguageDynamic()[additionalFeatures[i].obj.name].str;
        }
    }
    
    [Serializable]
    public class Item
    {
        public GameObject obj;
        public int price;
    }
}
