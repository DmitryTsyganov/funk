﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

[System.Serializable]
public class InputVerifyer : MonoBehaviour
{
    public Animator KeyboardAnimator;

    public InputFieldHandler mainInput;
    public Button fakeInputFieldButton;
    public Text fakeInputFieldButtonText;
    public GameObject InvisibleButton;
    public DeleteRedPartNotification notification;

    private string prevInput = null;
    private string[] requiredFunctions = {};
    private string[] allowedFunctions = { };
    private int prevPos = 0;

    // Use this for initialization
    void Start()
    {
        if (mainInput != null && mainInput.Input.text.Length != 0)
            fakeInputFieldButtonText.text = mainInput.Input.text.Replace(requiredFunctions[0],
                                "<color=#E12F0BFF>" + requiredFunctions[0] + "</color>");
    }

    // Update is called once per frame
    
   void Update()
   {
        /*
        Debug.Log(mainInput.caretPosition);
        correctCaretPosition(mainInput);
        
        prevPos = mainInput.caretPosition;
        */
    }

    public void activeInputField()
    {
        if (InvisibleButton.activeSelf)
            return;
        InvisibleButton.SetActive(true);
        EventSystem.current.SetSelectedGameObject(mainInput.gameObject, null);
        KeyboardAnimator.SetBool("Open", true);
    }

    private void correctCaretPosition(InputField input)
    {
        Debug.Log("open " + isInsideOfOpenTag(input.text, input.caretPosition));

        //We assume that player wants to edit text before unchangeble string
        if (isInsideOfOpenTag(input.text, input.caretPosition) && 
            input.caretPosition - prevPos > 1)
        {
            moveToClosestBeginningOfTag(input);
        }

        Debug.Log("close " + isInsideOfCloseTag(input.text, input.caretPosition));

        //Same, except after unchangable string
        if (isInsideOfCloseTag(input.text, input.caretPosition) &&
            input.caretPosition - prevPos > 1)
        {
            moveToClosestEndOfTag(input);
        }

        //1 symbol difference most probably means pressing arrow buttons,
        //so player moves from left to right
        if (isInsideOfOpenTag(input.text, input.caretPosition) &&
            input.caretPosition - prevPos == 1)
        {
            //moveToEnd(input);
        }

        if (isInsideOfCloseTag(input.text, input.caretPosition) &&
            input.caretPosition - prevPos == 1)
        {
            //moveToStart(input);
        }
    }

    private void moveToEnd(InputField input)
    {
        var text = input.text;
        int i = input.caretPosition;
        bool flag = false;

        while (text[i] != '>' && !flag && i < text.Length)
        {
            ++i;
            if (text[i] == '>')
            {
                flag = true;
            }
        }

        input.caretPosition = i + 1;
    }

    private void moveToStart(InputField input)
    {
        var text = input.text;
        int i = input.caretPosition;
        bool flag = false;

        while (text[i] != '<' && !flag && i > 0)
        {
            --i;
            if (text[i] == '<')
            {
                flag = true;
            }
        }
        input.caretPosition = i;
    }

    private bool isInsideTag(string text, int pos)
    {
        for (int i = pos; i < text.Length; ++i)
        {
            if (text[i] == '>')
            {
                return true;
            }
            else if (text[i] == '<')
            {
                return false;
            }
        }
        return false;
    }

    private void moveToClosestEndOfTag(InputField input)
    {
        var text = input.text;
        int i = input.caretPosition;

        while (text[i] != '>' && i < text.Length - 1) ++i;

        input.caretPosition = i + 1 < text.Length ? i + 1 : text.Length;
        input.selectionFocusPosition = i + 1 < text.Length ? i + 1 : text.Length;
    }

    private void moveToClosestBeginningOfTag(InputField input)
    {
        var text = input.text;
        int i = input.caretPosition;

        while (text[i] != '<' && i >= 0) --i;

        input.caretPosition = i > 0 ? i : 0;
        input.selectionFocusPosition = i > 0 ? i : 0;
    }

    private bool isInsideOfOpenTag(string text, int pos)
    {
        if (pos == text.Length) --pos;

        for (int i = pos; i >= 0; --i)
        {
            if (text[i] == '<' && text[i + 1] != '/')
            {
                return true;

            } else if (text[i] == '<')
            {
                return false;
            }
        }
        return false;
    }

    private bool isInsideOfCloseTag(string text, int pos)
    {
        if (pos == text.Length) --pos;
        bool flag = false;

        for (int i = pos; i >= 0; --i)
        {
            if (text[i] == '<' && text[i + 1] == '/')
            {
                return true;
            }
            if (text[i] == '>' && flag)
            {
                return false;
            }
        }
        return false;
    }

    public void setPrevInput(string input)
    {
        if (prevInput == null)
        {
            prevInput = input;
        }
    }

    public void setReqiredFunctions(string[] functions)
    {
        requiredFunctions = functions;
    }

    public void setDefaultFunction(string function)
    {
        function = Regex.Replace(function, @"[\d\+\-\*\/\#\(\)\.\^]", " ");
        function = Regex.Replace(function, @"[ ]{2,}", " ");

        //Debug.Log("allowed string " + function + "1\n");

        var temp = function.Split(' ');

        int allowedLength = 0;

        foreach (var VARIABLE in temp)
        {
            if (VARIABLE != string.Empty) ++allowedLength;
        }

        allowedFunctions = new string[allowedLength];
        int i = 0;

        //Debug.Log("\nAllowed functions are "  + '\n');
        foreach (var VARIABLE in temp)
        {
            if (VARIABLE != string.Empty)
            {
                allowedFunctions[i] = VARIABLE;
                ++i;
                //Debug.Log(VARIABLE + "\n");
            }
            
        }
    }

    public bool verifyInput()
    {
        bool isValid = true;

        if (mainInput != null && !ScenesParameters.Devmode)
        {
            string text = mainInput.Input.text;

            while (text.Contains("#"))
            {
                text = text.Replace("#", "/");
            }
            
            foreach (string function in requiredFunctions)
            {
                if (text.IndexOf(function, StringComparison.Ordinal) == -1)
                {
                    isValid = false;
                    notification.RedPartDeletingAttempt();
                }
            }

            string clearString = text.Clone().ToString();

            foreach (string function in requiredFunctions)
            {
                clearString = clearString.Replace(function, string.Empty);
            }

            clearString = Regex.Replace(clearString, @"[\+\-\*\/\#\(\)\.\^\d]", string.Empty);

            foreach (string VARIABLE in allowedFunctions)
            {
                clearString = clearString.Replace(VARIABLE, string.Empty);
            }

            if (clearString.Length != 0)
            {
                isValid = false;
            }

            if (isValid)
            {
                prevInput = text;
            }
            else
            {
                mainInput.Input.text = prevInput;
            }
        }

        #if UNITY_EDITOR
        if (ScenesParameters.Devmode)
        {
            prevInput = mainInput.Input.text;
        } 
        #endif
        if (requiredFunctions.Length > 0 && requiredFunctions[0].Length > 0)
        {
            fakeInputFieldButtonText.text = prevInput.Replace(requiredFunctions[0], "<color=#E12F0BFF>" + requiredFunctions[0] + "</color>");
        }
        else
        {
            fakeInputFieldButtonText.text = prevInput; 
        }
            

        return isValid;
    }
}
