using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyStarsPropmptSetUp : MonoBehaviour {

    public Button BuyButton;
    public GameObject watchAdForFreeText;
    public GameObject BackText;
    public GameObject BuyButtonText;

    // Use this for initialization
    void Start () {
        LanguageManager.setText(BackText, LanguageManager.getLanguage().back);
        
        LanguageManager.setText(watchAdForFreeText, LanguageManager.getLanguage().get_for_free);
    }

    void OnEnable()
    {
        if (Shop.CanBuyHint())
        {
            BuyButton.gameObject.SetActive(true);
            LanguageManager.setText(BuyButtonText, String.Format(LanguageManager.getLanguage().buy_hint, Shop.hintPrice));
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
