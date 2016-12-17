using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScreenSetUp : MonoBehaviour
{

    public GameObject PlayButtonText;
    public GameObject OptionsButtonText;
    public GameObject ShopButtonText;
    public GameObject LogoImageText;
    public GameObject LangugePrompt;

    // Use this for initialization
    void Start ()
    {
        MuteHandler.turnSound(Saver.isSoundOn());
        StartCoroutine(WaitForLanguage());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    IEnumerator WaitForLanguage()
    {
        if (LanguageManager.getLanguage() == null)
        {

            string language = Saver.getPreferedLanguage();
            if (language != null)
            {
                LanguageManager.setLanguage(language);
            }
            else
            {
                LangugePrompt.SetActive(true);
            }

            while (true)
            {
                if (LanguageManager.getLanguage() == null)
                {
                    yield return new WaitForSeconds(1);
                }
                else
                {
                    LangugePrompt.SetActive(false);
                    setLanguage();
                    yield break;
                }
            }
        }
        else
        {
            setLanguage();
        }
    }

    private void setLanguage()
    {
        LanguageManager.setText(PlayButtonText, LanguageManager.getLanguage().play);
        LanguageManager.setText(OptionsButtonText, LanguageManager.getLanguage().options);
        LanguageManager.setText(ShopButtonText, LanguageManager.getLanguage().shop);
        LanguageManager.setText(LogoImageText, LanguageManager.getLanguage().developer);
    }
}
