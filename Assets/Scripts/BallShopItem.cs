using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallShopItem : MonoBehaviour {
    public string Name;
    public Image image;

    public void Start()
    {  
        image.sprite = isBought() ? Resources.Load<Sprite>("BallTexture/" + Name + "Icon") : Resources.Load<Sprite>("BallTexture/" + "closeBall");
    }

	void Update () {
        image.color = isSelected() ? Color.white : Color.gray;
    }

    public void Click() {
        if (isBought())
        {
            //BallParametrs.ballSprite = image.sprite;
            GameObject ballSprite = Resources.Load<GameObject>("BallTexture/" + Name);
            BallParametrs.Renderer = ballSprite.GetComponent<SpriteRenderer>();
            BallParametrs.Controller = ballSprite.GetComponent<Animator>().runtimeAnimatorController;
        }
        else {
            if (Shop.Buy(Name))
            {
                image.sprite = Resources.Load<Sprite>("BallTexture/" + Name + "Icon");
                
                print(Name);
                //BallParametrs.ballSprite = image.sprite;
                GameObject ballSprite = Resources.Load<GameObject>("BallTexture/" + Name);
                BallParametrs.Renderer = ballSprite.GetComponent<SpriteRenderer>();
                BallParametrs.Controller = ballSprite.GetComponent<Animator>().runtimeAnimatorController;
            }
        }
    }

    private bool isBought()
    {
        return Name == "Default" || PlayerPrefs.GetString(Name) == "Buyed";
    }

    private bool isSelected()
    {
        //return BallParametrs.ballSprite == image.sprite;

        if (BallParametrs.Renderer != null && image.sprite != null)
        {
            return BallParametrs.Renderer.name + "Icon" == image.sprite.name;
        }
        return false;
    }
}
