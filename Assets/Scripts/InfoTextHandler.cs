using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextHandler : MonoBehaviour
{

    public GameObject BackText;

	// Use this for initialization
	void Start () {
		setLanguage();
	}

	// Update is called once per frame
	void Update () {

	}

    public void Click()
    {
        Destroy(gameObject);
    }

    void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText(BackText, LanguageManager.getLanguage().back);
    }
}
