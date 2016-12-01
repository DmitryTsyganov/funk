using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    public GameObject loadingImage;
    public AudioSource ButtonAudio;

	public void LoadScene(int level)
    { 
		if(loadingImage) loadingImage.SetActive(true);

        if (level != SceneManager.GetActiveScene().buildIndex)
            ScenesParameters.PreviousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(level);
    }
	public void Continue(){
		LoadScene (ScenesParameters.PreviousSceneIndex);
	}

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) LoadScene(ScenesParameters.PreviousSceneIndex);
    }

}
