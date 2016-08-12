using UnityEngine;
using System.Collections;

public class ShopBallSetUp : MonoBehaviour
{
    public GameObject BackButtonText;
    public GameObject TopInstructionText;

    // Use this for initialization
    void Start () {
        setLanguage();
    }

    void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText(BackButtonText, LanguageManager.getLanguage().back);
        LanguageManager.setText(TopInstructionText, LanguageManager.getLanguage().choose_ball + ' ' +
                                Shop.ballPrice + ' ' + LanguageManager.getLanguage().stars);
    }
}
