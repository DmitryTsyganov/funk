using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RateButtonScript : MonoBehaviour {

    private const string sectionNameDummy = "{0}";
    private bool isDesicionMade = false;

    public GameObject RateText;
    public GameObject YesButtonText;
    public GameObject NoButtonText;

	// Use this for initialization
	void Start () {
       setLanguage();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void HandleTheButton(bool desicion)
    {
        if (!isDesicionMade)
        {
            print("yeah");
            LanguageManager.setText(RateText,
                desicion ? LanguageManager.getLanguage().rate_prompt_yes : LanguageManager.getLanguage().rate_prompt_no);
            LanguageManager.setText(YesButtonText, LanguageManager.getLanguage().sure);
            LanguageManager.setText(NoButtonText, LanguageManager.getLanguage().later);
            isDesicionMade = true;
        } else
        {
            if (desicion)
            {
#if UNITY_EDITOR
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.NoCHgames.func");
#elif UNITY_ANDROID
                Application.OpenURL("market://details?id=com.NoCHgames.func");
                Saver.SetRated();
                
#elif UNITY_IPHONE
                //Application.OpenURL("");
#endif
            }
            else
            {
                
            }
            SceneManager.LoadScene(1);
            //transform.parent.gameObject.SetActive(false);
        }
    }

    private void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager
            .setText(
            RateText, 
            LanguageManager
            .getLanguage()
            .rate_prompt_1
            .Replace(sectionNameDummy, ScenesParameters.Section));
        LanguageManager.setText(YesButtonText, LanguageManager.getLanguage().yeah);
        LanguageManager.setText(NoButtonText, LanguageManager.getLanguage().not_really);
    }
}
