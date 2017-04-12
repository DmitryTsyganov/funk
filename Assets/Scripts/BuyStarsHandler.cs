using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyStarsHandler : MonoBehaviour
{
    public GameObject BuyStarsText;
    private bool isLanguageSet = false;

	// Use this for initialization
	void Start () {

	}

    private void OnEnable()
    {
        if (!isLanguageSet && LanguageManager.getLanguage() != null)
        {
            setLanguage();
            isLanguageSet = true;
        }
    }

    // Update is called once per frame
	void Update () {
		
	}

    private void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        var language = LanguageManager.getLanguage();
        LanguageManager.setText(BuyStarsText, language.buy + "\n" + Shop.StarsUltimate + "\n" + language.stars);
    }

    public void Click()
    {
        IAPHandler.GetInstance().BuyProduct("million_stars");
    }
}
