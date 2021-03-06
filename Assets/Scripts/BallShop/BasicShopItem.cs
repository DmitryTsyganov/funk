﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasicShopItem : MonoBehaviour {

    public string Name;
    public int price;
    public GameObject NotEnoughStars;
    public BallShop ballShop;
    public Image ballImage;
    public Image lockImage;
    public Image StarImage;
    public Text ObjNameText;
    public Text PriceText;

    protected SpriteRenderer spriteRenderer;

    public void basicShopItemStart()
    {
        ballShop = FindObjectOfType<BallShop>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!isBought())
        {
            //("not bought");
            setNotBoughtState();
        }
        else
        {
            setBoughtState();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool isBought()
    {
        return Name == "Default" || Saver.isBallBought(Name);
    }

    public void setSelectedState()
    {
        ballImage.color = Color.white;
    }

    public void setNotSelectedState()
    {
        ballImage.color = Color.gray;
    }

    public void setBoughtState()
    {
        lockImage.gameObject.SetActive(false);
    }

    protected void handleNotEnoughMoney()
    {
        Instantiate(NotEnoughStars);
    }

    private void setNotBoughtState()
    {
        lockImage.gameObject.SetActive(true);
        PriceText.text = price.ToString();
        StarImage.gameObject.GetComponent<RectTransform>().pivot =
            new Vector2(0.67f + 0.07f * price.ToString().Length, 0.29f);

    }


}
