using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {

    public GameObject loadingImage;

	public void LoadScene(int level)
    {
		if(loadingImage)
        loadingImage.SetActive(true);

        if (Application.loadedLevel != 4 && Application.loadedLevel != 5)
        {
            ScenesParameters.PreviousSceneIndex = Application.loadedLevel;
        }
        Application.LoadLevel(level);
    }
	public void Continue(){
		LoadScene (ScenesParameters.PreviousSceneIndex);
	}

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) LoadScene(ScenesParameters.PreviousSceneIndex);
    }

}
