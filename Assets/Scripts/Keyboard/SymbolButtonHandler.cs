using UnityEngine;
using UnityEngine.UI;

public class SymbolButtonHandler : MonoBehaviour
{
    public Text Input;
    public InputFieldHandler FunctionField;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        FunctionField.AddCharacter(Input.text);
    }
}
