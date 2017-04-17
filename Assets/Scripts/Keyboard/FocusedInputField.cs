using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FocusedInputField : InputField
{

    public static bool IsSelected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnDisable()
    {
        base.OnDisable();
        print("disabled");
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        if (!IsSelected)
        {
            base.OnDeselect(eventData);
        }
    }
}
