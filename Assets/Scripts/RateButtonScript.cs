using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RateButtonScript : MonoBehaviour {

    private const string sectionNameDummy = "{0}";
    private bool isDesicionMade = false;

    public Text RateText;
    public Text YesButtonText;
    public Text NoButtonText;

	// Use this for initialization
	void Start () {
        RateText.text = RateText.text.Replace(sectionNameDummy, ScenesParameters.Section);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void HandleTheButton(bool desicion)
    {
        if (!isDesicionMade)
        {
            if (desicion)
            {

            }
            else
            {

            }
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
    }
}
