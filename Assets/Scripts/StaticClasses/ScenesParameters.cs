using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScenesParameters
{
    private static int levelsCompletedInSession = 0;
    public static int LevelCompletedInSession
    {
        get
        {
            return levelsCompletedInSession;
        }

        set
        {
            if (!(section == "linear" && currentLevel < RewardedVideoUnityAdsManager.MidLevelVideoInterval))
                levelsCompletedInSession = value;
        }
    }

    private static Dictionary<string, int> scenesOrder = new Dictionary<string, int>
    {
        {"linear", 0},
        {"power", 1},
        {"root", 2},
        {"logarithm", 3},
        {"trigonometric", 4}
    };
    public static Dictionary<string, int> ScenesOrder
    {
        get { return scenesOrder; }
    }

    public static bool isValid { get; set; }

    private static float levelOffsetY = 2.5f;
    public static float LevelOffsetY
    {
        get
        {
            return levelOffsetY;
        }
    }

    private static bool devMode = true;
    public static bool Devmode
    {
        get
        {
            return devMode;
        }
        set
        {
            devMode = value;
        }
    }

    private static string levelName = "level";
    public static string LevelName
    {
        get
        {
            return levelName;
        }
        set
        {
            levelName = value;
        }
    }

    private static string levelsDirectory = "Levels";
    public static string LevelsDirectory
    {
        get
        {
            return levelsDirectory;
        }
        set
        {
            levelsDirectory = value;
        }
    }

    private static string languagesDirectory = "Languages";
    public static string LanguagesDirectory
    {
        get
        {
            return languagesDirectory;
        }
        set
        {
            languagesDirectory = value;
        }
    }

    private static string languagesDynamicDirectory = "ShopTranslation";
    public static string LanguagesDynamicDirectory
    {
        get
        {
            return languagesDynamicDirectory;
        }
        set
        {
            languagesDynamicDirectory = value;
        }
    }

    private static int currentLevel;
    public static int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }

    private static int levelsNumber;
    public static int LevelsNumber
    {
        get
        {
            return levelsNumber;
        }
        set
        {
            levelsNumber = value;
        }
    }

    private static string section;
    public static string Section
    {
        get
        {
            return section;
        }
        set
        {
            section = value;
        }
    }
	private static int previouSceneIndex;
	public static int PreviousSceneIndex
	{
		get {
			return previouSceneIndex;
		}
		set {
			previouSceneIndex = value;
		}
	}

	private static string TrueFunction;
	public static string trueFunction{
		get{
			return TrueFunction;
		}
		set{
			TrueFunction = value;
		}
	}
}
