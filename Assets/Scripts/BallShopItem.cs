using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallShopItem : MonoBehaviour {
    public string Name;
    public Image image;

    public void Start()
    {  
        image.sprite = isBought() ? Resources.Load<Sprite>("BallTexture/" + Name + "Icon") : 
                        Resources.Load<Sprite>("BallTexture/" + "closeBall");
    }

	void Update () {
        image.color = isSelected() ? Color.white : Color.gray;
    }

    public void Click() {
        if (isBought())
        {
            BallParametrs.setBall(Name);
        }
        else {
            if (Shop.Buy(Name))
            {
                image.sprite = Resources.Load<Sprite>("BallTexture/" + Name + "Icon");
                
                BallParametrs.setBall(Name);
            }
        }
    }

    private bool isBought()
    {
        return Name == "Default" || Saver.isBallBought(Name);
    }

    private bool isSelected()
    {
        if (BallParametrs.Renderer != null && image.sprite != null)
        {
            return BallParametrs.Renderer.name + "Icon" == image.sprite.name;
        }
        return false;
    }
}
