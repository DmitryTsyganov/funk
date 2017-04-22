using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FocusedInputField : InputField
{
    public static bool IsSelected;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {

	}

    protected override void OnDisable()
    {
        try
        {
            base.OnDisable();
            print("disabled");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

    }

    public override void OnSelect(BaseEventData eventData)
    {

    }

    public override void OnPointerClick(PointerEventData eventData)
    {

    }
}
