using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldHandler : MonoBehaviour
{
    public Text FakeInputText;
    public InputVerifyer Verifyer;
    public Text Input;
    public Text CaretText;

    public int caretPosition = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddCharacter(string character)
    {
        Input.text = Input.text.Insert(caretPosition, character);
        if (Verifyer.verifyInput())
        {
            caretPosition += 1;
            CaretText.text =
                Input.text.Substring(0, caretPosition);
        }
    }

    public void DeleteCharacter()
    {
        if (caretPosition == 0)
            return;
        Input.text = Input.text.Remove(caretPosition - 1, 1);

        if(!Verifyer.verifyInput())
            return;

        caretPosition -= 1;

        CaretText.text =
            Input.text.Substring(0, caretPosition);

        if (caretPosition == 0)
        {
            CaretText.gameObject.SetActive(false);
        }
    }
}
