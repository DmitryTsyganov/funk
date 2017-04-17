using System;
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

    public override void OnDeselect(BaseEventData eventData)
    {
        if (!IsSelected)
        {
            base.OnDeselect(eventData);
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}
