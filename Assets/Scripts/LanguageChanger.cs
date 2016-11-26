using UnityEngine;
using System.Collections;

public class LanguageChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setLanguage(string languageName)
    {
        LanguageManager.setLanguage(languageName);
    }
}
