using UnityEngine;
using System.Collections;

public class AddonShopItemHandler : BasicShopItem
{
    // Use this for initialization
    void Start()
    {
        //basicShopItemStart();
    }

    void LateUpdate()
    {
        updateAddonItemActiveState();
    }

    void updateAddonItemActiveState()
    {
        ballImage.sprite = spriteRenderer.sprite;
        ballImage.color = BallParametrs.isAddonActive(Name) ? Color.white : Color.grey;
        PriceText.color = Shop.StarScore >= price ? Color.black : Color.red;
    }

    public void Click()
    {
        if (isBought())
        {
            if (BallParametrs.isAddonActive(Name))
            {
                BallParametrs.removeAddonName(Name);
            }
            else
            {
                BallParametrs.addAddonName(Name);
            }
        }
        else {
            if (Shop.BuyForPrice(Name, price))
            {
                if(!Saver.sawFirstBall()) Saver.dontShowFirstBall();
                ballShop.updateStarsCountText();
                setBoughtState();
                BallParametrs.addAddonName(Name);
            }
            else
            {
                handleNotEnoughMoney();
            }
        }
    }

    public void GetForFree()
    {
        Shop.BuyForFree(Name);
        setBoughtState();
        BallParametrs.addAddonName(Name);
    }
}
