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
        ballImage.sprite = renderer.sprite;
        ballImage.color = BallParametrs.isAddonActive(Name) ? Color.white : Color.grey;
        ObjNameText.color = Shop.StarScore > price ? Color.white : Color.red;
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
        Shop.ButForFree(Name);
        setBoughtState();
        BallParametrs.addAddonName(Name);
    }
}
