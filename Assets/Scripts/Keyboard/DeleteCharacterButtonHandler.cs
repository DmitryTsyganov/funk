using UnityEngine;
using UnityEngine.UI;

public class DeleteCharacterButtonHandler : MonoBehaviour
{
    public InputFieldHandler FunctionInput;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        FunctionInput.DeleteCharacter();
    }
}
