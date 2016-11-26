using UnityEngine;
using System.Collections;

public class BallShopItemHandler : BasicShopItem
{
    // Use this for initialization
    void Start()
    {
        //basicShopItemStart();
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
                ballShop.updateStarsCountText();
                setBoughtState();
                BallParametrs.setBall(Name);
            }
            else
            {
                handleNotEnoughMoney();
            }
        }
    }

    public void getForFree()
    {
        Shop.ButForFree(Name);
        setBoughtState();
        BallParametrs.setBall(Name);
    }

    protected void updateBallItemActiveState()
    {
        //TODO: find a better way
        ballImage.sprite = renderer.sprite;
        ballImage.color = BallParametrs.BallName == Name ? Color.white : Color.grey;
        PriceText.color = Shop.StarScore > price ? Color.black : Color.red;
    }
}
