using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CompletedScripts : MonoBehaviour {

    public void Start()
    {
        LanguageManager.setText("Text_Completed", LanguageManager.getLanguage().completed);
        LanguageManager.setText("StarCountText", "+" + Shop.levelAward + " " + LanguageManager.getLanguage().stars);
    }

    public void replay()
    {
        CompletedScreen.getInstanse().SetActive(false);
        SceneManager.LoadScene(3);
    }

    public void continueGame()
    {
        CompletedScreen.getInstanse().SetActive(false);

        Debug.Log(ScenesParameters.CurrentLevel + 1);
        Debug.Log(ScenesParameters.LevelsNumber);

        if (ScenesParameters.LevelsNumber >= ScenesParameters.CurrentLevel + 1)
        {
            ScenesParameters.CurrentLevel++;
        }
        SceneManager.LoadScene(3);
    }
    
}
