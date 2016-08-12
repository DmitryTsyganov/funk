using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class StarScoreText : MonoBehaviour {

	public Text ScoreStartText;
	public Text hintText;
	public GameObject hintWindow;

    void Start()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText("ThanksText", LanguageManager.getLanguage().thanks);
    }

	void Update () {
        ScoreStartText.text = Shop.StarScore.ToString();
    }

	public void AddHint(){
		if (Shop.BuyHint()) {
            //hintText.text = hintText.text.Replace ("{}", ScenesParameters.trueFunction);
		    hintText.text = ScenesParameters.trueFunction;
            hintWindow.SetActive (true);
            Saver.saveHint();
            ScoreStartText.text = Shop.StarScore.ToString();
        }
	}
}
