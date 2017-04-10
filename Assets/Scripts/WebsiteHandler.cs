using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebsiteHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenSite()
    {
        Application.OpenURL("http://nochgames.ru/");
    }

    public void OpenLicense()
    {
        Application.OpenURL("http://creativecommons.org/licenses/by/3.0/");
    }
}
