using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class GameParametrs {

	private static string lang{ get; set;}
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
	}
}

public static class BallParametrs{

	private static Sprite BallSprite{ get; set;}

	public static Sprite ballSprite {
		get{ 
			return BallSprite;
		}
		set{ 
			BallSprite = value;
			PlayerPrefs.SetString ("BallSpriteName", BallSprite.name);
		}
	}

    private static SpriteRenderer renderer { get; set; }
    public static SpriteRenderer Renderer
    {
        get { return renderer; }
        set
        {
            renderer = value;
            PlayerPrefs.SetString("BallSpriteName", renderer.name);
        }
    }

    public static void setDefaultBall()
    {
        var defaultBall = Resources.Load<GameObject>("BallTexture/" + "Default");
        Renderer = defaultBall.GetComponent<SpriteRenderer>();
        Controller = defaultBall.GetComponent<Animator>().runtimeAnimatorController;
    }

    public static RuntimeAnimatorController Controller;
}
