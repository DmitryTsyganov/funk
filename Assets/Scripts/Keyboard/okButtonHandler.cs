using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class okButtonHandler : MonoBehaviour
{
    public GameObject InvisibleButton;
    public Animator KeyboardAnimator;
    public GameObject mainInput;

    private Button _runButton;

	// Use this for initialization
	void Start () {
	    var button = GameObject.Find("RunButton");
	    _runButton = button.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        InvisibleButton.SetActive(false);
        FocusedInputField.IsSelected = false;
        mainInput.transform.SetSiblingIndex(mainInput.transform.GetSiblingIndex() - 1);
        KeyboardAnimator.SetBool("Open", false);
        _runButton.onClick.Invoke();
    }
}
