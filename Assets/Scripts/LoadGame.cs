using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    public GameObject loadingImage;
    public AudioSource ButtonAudio;

    //if a scene contains several LoadGameScripts, only one should answer to the back button
    private static bool canLoad;

    public LoadGame()
    {
        canLoad = true;
    }

    public void LoadScene(int level)
	{
	    print("level to load :" + level);
	    print("current level " + SceneManager.GetActiveScene().buildIndex);
		if(loadingImage) loadingImage.SetActive(true);

        if (level != SceneManager.GetActiveScene().buildIndex)
            ScenesParameters.PreviousSceneIndex = SceneManager.GetActiveScene().buildIndex;
	    print("previous scen index " + ScenesParameters.PreviousSceneIndex);
	    SceneManager.LoadScene(level);
    }
	public void Continue(){
		LoadScene (ScenesParameters.PreviousSceneIndex);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canLoad && SceneManager.GetActiveScene().buildIndex != 0)
        {
            canLoad = false;
            Continue();
        }
    }
}
