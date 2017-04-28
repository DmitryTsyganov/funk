using UnityEngine;
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

    protected SpriteRenderer renderer;

    public void basicShopItemStart()
    {
        ballShop = FindObjectOfType<BallShop>();

        renderer = GetComponent<SpriteRenderer>();
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

    private void setSelectedState()
    {

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
