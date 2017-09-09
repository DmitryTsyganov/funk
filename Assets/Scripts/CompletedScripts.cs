using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedScripts : InternetDependantBasic
{

    public static bool ShowRateTheGameScreen = false;

    public GameObject RateTheGameScreen;

    public void Start()
    {
        DoStart();
        LanguageManager.setText("Text_Completed", LanguageManager.getLanguage().completed);
        //LanguageManager.setText("StarCountText", "+" + Shop.levelAward + " " + LanguageManager.getLanguage().stars);
    }

    private void OnEnable()
    {
        CompletedScreen.dontShowStars();
    }

    public void replay()
    {
        CompletedScreen.getInstanse().SetActive(false);
        //SceneManager.LoadScene(3);
    }

    public void continueGame()
    {
        //CompletedScreen.getInstanse().SetActive(false);

        //Debug.Log(ScenesParameters.CurrentLevel + 1);
        //Debug.Log(ScenesParameters.LevelsNumber);

        if (ScenesParameters.LevelsNumber > ScenesParameters.CurrentLevel)
        {
            ++ScenesParameters.CurrentLevel;
            if (_isActive && ScenesParameters.LevelCompletedInSession > 0 && 
                (ScenesParameters.LevelCompletedInSession + 1) % RewardedVideoUnityAdsManager.MidLevelVideoInterval == 0)
            {
                RewardedVideoUnityAdsManager.GetInstance().ShowVideo();
            }
            else
            {
                ++ScenesParameters.LevelCompletedInSession;
                SceneManager.LoadScene(3);
            }
        }
        else if (ScenesParameters.LevelsNumber == ScenesParameters.CurrentLevel) { 

            if (ShowRateTheGameScreen && !Saver.HasRated())
            {
                Instantiate(RateTheGameScreen);
                Saver.SetRated();
                ShowRateTheGameScreen = false;
            } else
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
