using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeHintButton : MonoBehaviour
{
    private Button HintButton;

	// Use this for initialization
	void Start ()
	{
	    HintButton = GameObject.Find("ButtonHint").GetComponent<Button>();
	}

    public void Click()
    {
        HintButton.onClick.Invoke();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
