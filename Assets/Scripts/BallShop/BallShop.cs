using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallShop : MonoBehaviour
{
    public const int ballShopReward = 40;

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
    public GameObject BackText;
    public List<Item> ballsToSell = new List<Item>();
    public List<Item> additionalFeatures = new List<Item>();
    public int BallsToBuy;

    private BallShopItemHandler[] ballButtonHandlers;
    private GameObject[] ballButtons;

    private static bool doCountBallsToBuy = false;

    // Use this for initialization
    void Start ()
    {
        setLanguage();
        BallParametrs.start();
        updateStarsCountText();

        ballButtonHandlers = new BallShopItemHandler[ballsToSell.Count];
        ballButtons = new GameObject[ballsToSell.Count];

        int i = 0;
        foreach (var item in ballsToSell)
        {
            var button = createButton(item);
            ballButtons[i] = button;
            ballButtonHandlers[i] = button.transform.Find("BallShopItem").gameObject.GetComponent<BallShopItemHandler>();
            ++i;
        }

        foreach (var item in additionalFeatures)
        {
            var button = createButton(item);
            transformButton(button);
        }
        BallsToBuy = countBallsToBuy();

        ActivateAddons();
        ActivateBalls();
    }

    private GameObject createButton(Item item)
    {
        var buttonWrapper = Instantiate(ballShopItemPrefab);
        var button = buttonWrapper.transform.Find("BallShopItem").gameObject;
        buttonWrapper.transform.parent = ContentBalls.transform;
        buttonWrapper.transform.localScale = Vector3.one;
        button.GetComponent<Animator>().runtimeAnimatorController =
            item.obj.GetComponent<Animator>().runtimeAnimatorController;
        button.GetComponent<SpriteRenderer>().sprite =
            item.obj.GetComponent<SpriteRenderer>().sprite;
        var handler = button.GetComponent<BallShopItemHandler>();
        handler.price = item.price;
        handler.basicShopItemStart();
        handler.Name = item.obj.name;

        print(LanguageManager.getLanguageDynamic());
        foreach (var obj in LanguageManager.getLanguageDynamic().list)
        {
            print(obj.keys);
        }
        handler.ObjNameText.text = LanguageManager.getLanguageDynamic()[item.obj.name].str;
        return buttonWrapper;
    }

    private void transformButton(GameObject buttonWrapper)
    {
        var button = buttonWrapper.transform.Find("BallShopItem").gameObject;
        buttonWrapper.transform.parent = ContentAddons.transform;
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
        print("index "+index);
        print("lenght "+ handlersToBuy.Count);
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
        LanguageManager.setText(BackText, LanguageManager.getLanguage().back);
    }
    
    [Serializable]
    public class Item
    {
        public GameObject obj;
        public int price;
    }
}
