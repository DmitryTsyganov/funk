using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public static class GameParametrs {

	/*private static string lang{ get; set;}
	public static string Lang{
		get{ 
			return lang;
		}
		set{ 
			lang = value;
			PlayerPrefs.SetString ("Lang", value);
		}
	}

	public static void Continue(){
		SceneManager.LoadScene(ScenesParameters.PreviousSceneIndex);
	}*/
}

public static class BallParametrs
{

    public static RuntimeAnimatorController Controller { get; private set; }
    public static SpriteRenderer Renderer { get; private set; }
    public static string BallName { get; private set; }

    public static void setDefaultBall()
    {
        setBall("Default");
    }

    public static void setBall(string name)
    {
        BallName = name;
        GameObject sprite = Resources.Load<GameObject>("BallTexture/" + name);
        Renderer = sprite.GetComponent<SpriteRenderer>();
        Controller = sprite.GetComponent<Animator>().runtimeAnimatorController;
        Saver.saveBallSelection(name);
    }

    public static void start()
    {
        string savedBall = Saver.getSavedBall();

        if (Renderer == null)
        {
            if (Saver.isBallSelectionSaved())
            {
                setDefaultBall();
            }
            else
            {
                setBall(savedBall);
            }
        }
    }
}
