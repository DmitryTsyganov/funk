using UnityEngine;
using System.Collections;

public class DeleteAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //ScenesParameters.Devmode = false;
        //Screen.orientation = ScreenOrientation.Portrait;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DeleteProgress()
    {
        PlayerPrefs.DeleteAll();
    }
}
