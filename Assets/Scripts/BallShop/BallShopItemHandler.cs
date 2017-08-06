﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class BallShopItemHandler : BasicShopItem
{
    // Use this for initialization
    void Start()
    {
        basicShopItemStart();
        if (BallParametrs.BallName == Name)
        {
            ballShop.currentBall = this;
            setSelectedState();
        }
    }

    void LateUpdate()
    {
        updateBallItemActiveState();
    }

    public void Click()
    {
        if (isBought())
        {
            if (ballShop.currentBall != null)
            {
                ballShop.currentBall.setNotSelectedState();
            }
            ballShop.currentBall = this;
            setSelectedState();
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
                if(!Saver.sawFirstBall()) Saver.dontShowFirstBall();
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
        //ballImage.color = BallParametrs.BallName == Name ? Color.white : Color.grey;
        if(PriceText != null)
            PriceText.color = Shop.StarScore > price ? Color.black : Color.red;
    }
}
