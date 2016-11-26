using UnityEngine;
using System.Collections;

public static class ScenesParameters {

    public static bool isValid { get; set; }

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
