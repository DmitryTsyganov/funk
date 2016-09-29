using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    public GameObject loadingImage;

	public void LoadScene(int level)
    {
		if(loadingImage)
        loadingImage.SetActive(true);

        if (SceneManager.GetActiveScene().buildIndex != 4 && SceneManager.GetActiveScene().buildIndex != 5)
        {
            ScenesParameters.PreviousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
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
