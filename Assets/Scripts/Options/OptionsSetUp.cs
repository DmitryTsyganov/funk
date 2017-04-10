using UnityEngine;
using System.Collections;

public class OptionsSetUp : MonoBehaviour
{

    public GameObject DeleteProgressText;
    public GameObject BackButtonText;
    public GameObject Dev1NameText;
    public GameObject Dev2NameText;
    public GameObject Dev3NameText;
    public GameObject Dev1PositionText;
    public GameObject Dev2PositionText;
    public GameObject Dev3PositionText;
    public GameObject InfoText;

    // Use this for initialization
    void Start () {
        setLanguage();
    }

    void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText(DeleteProgressText, LanguageManager.getLanguage().delete_progress);
        LanguageManager.setText(BackButtonText, LanguageManager.getLanguage().back);
        LanguageManager.setText(Dev1NameText, LanguageManager.getLanguage().name_1);
        LanguageManager.setText(Dev2NameText, LanguageManager.getLanguage().name_2);
        LanguageManager.setText(Dev3NameText, LanguageManager.getLanguage().name_3);
        LanguageManager.setText(Dev1PositionText, LanguageManager.getLanguage().position_1);
        LanguageManager.setText(Dev2PositionText, LanguageManager.getLanguage().position_2);
        LanguageManager.setText(Dev3PositionText, LanguageManager.getLanguage().position_3);
        LanguageManager.setText(InfoText, LanguageManager.getLanguage().info);
    }
}
