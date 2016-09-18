using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyStarsPropmptSetUp : MonoBehaviour {

    public Button Yes;
    public Button AddStar;

    // Use this for initialization
    void Start () {
        LanguageManager.setText("PromptText", LanguageManager.getLanguage().buy_stars_prompt);
        LanguageManager.setText("BackButtonText", LanguageManager.getLanguage().back);
        if (Shop.CanBuyHint())
        {
            Yes.gameObject.SetActive(true);
            LanguageManager.setText("BuyButtonText", LanguageManager.getLanguage().buy);
        }
        
        LanguageManager.setText("WatchAdButtonText", LanguageManager.getLanguage().get_for_free);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
