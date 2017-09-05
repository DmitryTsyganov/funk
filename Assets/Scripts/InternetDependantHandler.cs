using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternetDependantHandler : MonoBehaviour
{
    public GameObject NoInternetImage;

    private const string PingAddress = "8.8.8.8";
    private const float CheckPeriodSeconds = 3f;
    private const float PingTimeout = 2f;

    private bool _isActive = false;

    // Use this for initialization
    protected void DoStart()
    {
        //print("internet dependant handler");
        if (Application.internetReachability ==
            NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            StartCoroutine(CheckInternet());
        }
        else
        {
            HandleNoInternet();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleNoInternet()
    {
        //print("no internet");
        NoInternetImage.SetActive(true);
        _isActive = false;
    }

    private void HandleInternetAvailable()
    {
        //print("internet is available");
        NoInternetImage.SetActive(false);
        _isActive = true;
    }

    private IEnumerator CheckInternet()
    {
        while (true)
        {
            var ping = new Ping(PingAddress);
            float timePassed = 0;
            yield return 0;
            bool isInternetAvailable = false;

            while (timePassed < PingTimeout)
            {
                if (!ping.isDone)
                {
                    timePassed += Time.deltaTime;
                    yield return 0;
                }
                else
                {
                    if (ping.time >= 0)
                    {
                        isInternetAvailable = true;
                    }
                    break;
                }
            }
            if (isInternetAvailable)
            {
                HandleInternetAvailable();
            }
            else
            {
                HandleNoInternet();
            }
            yield return new WaitForSeconds(CheckPeriodSeconds);
        }
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
