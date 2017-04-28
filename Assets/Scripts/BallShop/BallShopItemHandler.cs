using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class BallShopItemHandler : BasicShopItem
{
    // Use this for initialization
    void Start()
    {
        basicShopItemStart();
    }

    void LateUpdate()
    {
        updateBallItemActiveState();
    }

    public void Click()
    {
        if (isBought())
        {
            BallParametrs.setBall(Name);
        }
        else {
            if (Shop.BuyForPrice(Name, price))
            {
                Analytics.CustomEvent(AnalyticsParameters.BallBought,
                    new Dictionary<string, object> {
                        {"name", Name}});
                ballShop.updateStarsCountText();
                setBoughtState();
                BallParametrs.setBall(Name);
                BallShop.CountBallsToBuy();
            }
            else
            {
                handleNotEnoughMoney();
            }
        }
    }

    public void getForFree()
    {
        Shop.BuyForFree(Name);
        setBoughtState();
        BallParametrs.setBall(Name);
    }

    protected void updateBallItemActiveState()
    {
        //TODO: find a better way
        ballImage.sprite = renderer.sprite;
        ballImage.color = BallParametrs.BallName == Name ? Color.white : Color.grey;
        if(PriceText != null)
            PriceText.color = Shop.StarScore > price ? Color.black : Color.red;
    }
}
