using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAvailableScreen : CongratilationsScreen
{
    public GameObject ShopButtonText;

    private const float ButtonSizeCoefficient = 0.35f;
    private const float ButtonYCoefficient = 0.62f;

	// Use this for initialization
	void Awake()
	{
	    buttonSizeCoefficient = ButtonSizeCoefficient;
	    buttonYCoefficient = ButtonYCoefficient;
		setLanguage();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText(CongratilationsText, LanguageManager.getLanguage().congratilation_first_ball);
        LanguageManager.setText(BackText, LanguageManager.getLanguage().back);
        LanguageManager.setText(ShopButtonText, LanguageManager.getLanguage().shop);
    }
}
