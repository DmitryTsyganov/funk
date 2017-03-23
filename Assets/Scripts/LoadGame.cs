using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    public GameObject loadingImage;
    public AudioSource ButtonAudio;

    private const int GameIndex = 3;

    //if a scene contains several LoadGameScripts, only one should answer to the back button
    private static bool canLoad;

    public LoadGame()
    {
        canLoad = true;
    }

    public void LoadScene(int level)
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

	    ChangeTrackIfNecessary(currentLevel, level);

	    print("level to load :" + level);
	    print("current level " + currentLevel);
		if(loadingImage) loadingImage.SetActive(true);

        if (level != currentLevel)
            ScenesParameters.PreviousSceneIndex = currentLevel;
	    print("previous scene index " + ScenesParameters.PreviousSceneIndex);
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

    private void ChangeTrackIfNecessary(int currentLevel, int nextLevel)
    {
        if (currentLevel == GameIndex && nextLevel != GameIndex)
        {
            AudioPlayerStatic.GetInstance().PlayMenuTracks();
            print("Changing music to Menu");
        }

        if (currentLevel != GameIndex && nextLevel == GameIndex)
        {
            AudioPlayerStatic.GetInstance().PlayGameTracks();
            print("Changing music to Game");
        }
    }
}
