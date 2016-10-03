using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallShopItemHandler : MonoBehaviour {

    public string Name;
    public int price;
    public BallShop ballShop;
    public Image ballImage;
    public Image lockImage;
    public Image StarImage;
    public Text priceText;

    private SpriteRenderer renderer;

    // Use this for initialization
    void Start ()
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
	void Update () {
	
	}
    void LateUpdate()
    {
        //TODO: find a better way
        ballImage.sprite = renderer.sprite;
        ballImage.color = BallParametrs.BallName == Name ? Color.white : Color.grey;
        priceText.color = Shop.StarScore > price ? Color.white : Color.red;
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
        }
    }

    private bool isBought()
    {
        return Name == "Default" || Saver.isBallBought(Name);
    }

    private void setSelectedState()
    {
        
    }

    private void setBoughtState()
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
