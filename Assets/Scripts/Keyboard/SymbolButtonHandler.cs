using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ADBannerView = UnityEngine.iOS.ADBannerView;

public class SymbolButtonHandler : MonoBehaviour
{
    public Text Input;
    public InputField FunctionField;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        FunctionField.text = FunctionField.text.Insert(FunctionField.caretPosition, Input.text);
        FunctionField.caretPosition += 1;
    }
}
