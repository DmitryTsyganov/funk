﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasicShopItem : MonoBehaviour {

    public string Name;
    public int price;
    public BallShop ballShop;
    public Image ballImage;
    public Image lockImage;
    public Image StarImage;
    public Text priceText;

    protected SpriteRenderer renderer;

    

    protected void basicShopItemStart()
    {
        ballShop = FindObjectOfType<BallShop>();

        renderer = GetComponent<SpriteRenderer>();
        if (!isBought())
        {
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

    protected bool isBought()
    {
        return Name == "Default" || Saver.isBallBought(Name);
    }

    private void setSelectedState()
    {

    }

    protected void setBoughtState()
    {
        lockImage.gameObject.SetActive(false);
        priceText.gameObject.SetActive(false);
    }

    private void setNotBoughtState()
    {
        lockImage.gameObject.SetActive(true);
        priceText.text = price.ToString();
        StarImage.gameObject.GetComponent<RectTransform>().pivot =
            new Vector2(0.67f + 0.07f * price.ToString().Length, 1f);

    }


}