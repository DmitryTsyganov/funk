using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteCharacterButtonHandler : MonoBehaviour
{
    public InputField FunctionInput;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        var pos = FunctionInput.caretPosition;
        if (pos == 0)
            return;
        bool doMoveCarret = pos != FunctionInput.text.Length;
        FunctionInput.text = FunctionInput.text.Remove(pos - 1, 1);

        if (doMoveCarret)
            FunctionInput.caretPosition -= 1;
    }
}
