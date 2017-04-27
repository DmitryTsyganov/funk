using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyStarsPropmptSetUp : MonoBehaviour {

    public Button Yes;
    public Button AddStar;
    public GameObject watchAdForFreeText;
    public GameObject watchAdButton;

    // Use this for initialization
    void Start () {
        LanguageManager.setText("PromptText", String.Format(LanguageManager.getLanguage().buy_stars_prompt, Shop.hintPrice));
        LanguageManager.setText("BackButtonText", LanguageManager.getLanguage().back);
        
        LanguageManager.setText("WatchAdButtonText", LanguageManager.getLanguage().get_for_free);

        //watchAdButton.SetActive(false);
    }

    void OnEnable()
    {
        if (Shop.CanBuyHint())
        {
            Yes.gameObject.SetActive(true);
            LanguageManager.setText("BuyButtonText", LanguageManager.getLanguage().buy);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
