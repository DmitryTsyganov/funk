using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeThankYouHandler : MonoBehaviour
{
    private Button ThanksButton;

	// Use this for initialization
	void Start ()
	{

	}

    public void Click()
    {
        ThanksButton.onClick.Invoke();
    }

	// Update is called once per frame
	void Update ()
	{
	    if (ThanksButton != null)
	        return;
	    var button = GameObject.Find("ThanksButton");
	    if (button)
	    {
	        ThanksButton = button.GetComponent<Button>();
	    }
	}
}
