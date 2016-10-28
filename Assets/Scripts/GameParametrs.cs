using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
    public static Dictionary<string, GameObject> Addons = new Dictionary<string, GameObject>();

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

    public static void addAddonName(string name)
    {
        GameObject addon = Resources.Load<GameObject>("Addons/" + name);
        if (addon != null)
        {
            Addons[name] = addon;
            Saver.addChosenAddon(name);
        }
    }

    public static bool isAddonActive(string name)
    {
        return Addons.ContainsKey(name);
    }

    public static void removeAddonName(string name)
    {
        Addons.Remove(name);
        Saver.removeChosenAddon(name);
    }

    public static void start()
    {
        getSavedBalls();
        getSavedAddons();
    }

    private static void getSavedBalls()
    {
        if (Renderer == null)
        {
            string savedBall = Saver.getSavedBall();

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

    private static void getSavedAddons()
    {
        string[] addons = Saver.getChosenAddons();
        for (int i = 0; i < addons.Length; ++i)
        {
            GameObject addon = Resources.Load<GameObject>("Addons/" + addons[i]);
            if (addon != null)
            {
                Addons[addons[i]] = addon;
            }
        }
        
    }
}
