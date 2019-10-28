using UnityEngine;

public class CompletedScripts : InternetDependantBasic
{
    public LoadGame loadGame;

    public static bool ShowRateTheGameScreen = false;

    public GameObject RateTheGameScreen;

    private CompletedScreen _completedScreen;

    private void Awake()
    {
        _completedScreen = GameObject.Find("GameMechanicsInputs")
            .GetComponentInChildren<CompletedScreen>(true);
    }

    public void Start()
    {
        DoStart();
        LanguageManager.setText("Text_Completed", LanguageManager.getLanguage().completed);
        //LanguageManager.setText("StarCountText", "+" + Shop.levelAward + " " + LanguageManager.getLanguage().stars);
    }

    public void replay()
    {
        _completedScreen.gameObject.SetActive(false);
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
                loadGame.LoadScene(3);
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
                loadGame.LoadScene(1);
            }
        }
    }
}
