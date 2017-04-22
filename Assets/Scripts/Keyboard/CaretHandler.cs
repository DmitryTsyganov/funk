using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CaretHandler : Button
{
    public GameObject CaretText;
    public GameObject Caret;
    public InputFieldHandler Input;
    public GameObject RealText;

    private RectTransform _rect;
    private Text _caretText;
    private Text _inputText;
    private bool doCheck = false;
    private bool isFirst = true;

    private Vector2 localCursor;

	// Use this for initialization
	void Start ()
	{
	    RealText = GameObject.Find("InputText");
	    CaretText = GameObject.Find("CaretText");
	    Caret = GameObject.Find("CaretImage");
	    Input = GameObject.Find("InputFieldNoKeyboard").GetComponent<InputFieldHandler>();
	    _rect = GetComponent<RectTransform>();
	    _caretText = CaretText.GetComponent<Text>();
	    _inputText = RealText.GetComponent<Text>();
	}
	
	// Update is called once per frame
    void Update()
    {
	    if (!CaretText.activeSelf)
	    {
	        CaretText.SetActive(true);
	        Caret.SetActive(false);
	    }

	    RectTransform rt = (RectTransform) CaretText.transform;
	    if (!doCheck)
	        return;

        print(rt.rect.width + 20);
        print(_rect.rect.width / 2 + localCursor.x);
	    if (rt.rect.width + 20 < _rect.rect.width / 2 + localCursor.x && Input.caretPosition < _inputText.text.Length)
	    {
	        ++Input.caretPosition;
	        if(Caret.activeSelf)
	            Caret.SetActive(false);
	        _caretText.text = _inputText.text.Substring(0, Input.caretPosition);
	    }
	    else
	    {
	        if (isFirst)
	        {
	            isFirst = false;
	        }
	        else
	        {
	            doCheck = false;
	            if(!Caret.activeSelf)
	                Caret.SetActive(true);
	        }
	    }
	}

    public void PlaceCaret(int pos)
    {
        Input.caretPosition = pos;
        _caretText.text = _inputText.text.Substring(0, Input.caretPosition);
        localCursor.x = -_rect.rect.width / 2;
        CaretText.SetActive(false);
        doCheck = true;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        _caretText.text = "";
        CaretText.SetActive(false);

        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _rect, eventData.position, eventData.pressEventCamera, out localCursor))
            return;

        doCheck = true;
        isFirst = true;
        Input.caretPosition = 0;

        base.OnPointerClick(eventData);

    }

}
