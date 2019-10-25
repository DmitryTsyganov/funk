using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternetDependantHandler : InternetDependantBasic
{
    public GameObject NoInternetImage;

    protected void DoStart()
    {
        base.DoStart();
        InternetAvailable += HandleInternetAvailable;
        NoInternet += HandleNoInternet;
    }

    private void HandleNoInternet()
    {
        //print("no internet");
        NoInternetImage.SetActive(true);
    }

    private void HandleInternetAvailable()
    {
        //print("internet is available");
        NoInternetImage.SetActive(false);
    }

    public void Click()
    {
        if (_isActive)
        {
            OnClickHandler(EventArgs.Empty);
        }
    }

    protected virtual void OnClickHandler(EventArgs e)
    {
        EventHandler handler = OnClick;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    public event EventHandler OnClick;
}
