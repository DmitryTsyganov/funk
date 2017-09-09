using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternetDependantBasic : MonoBehaviour
{
    private const string PingAddress = "8.8.8.8";
    private const float CheckPeriodSeconds = 3f;
    private const float PingTimeout = 2f;

    protected delegate void InternetStatusHandler();
    protected bool _isActive { get; private set; }

    protected void DoStart()
    {
        _isActive = false;

        InternetAvailable += new InternetStatusHandler(HandleInternetAvailable);
        NoInternet += new InternetStatusHandler(HandleNoInternet);

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

    protected InternetStatusHandler InternetAvailable;
    protected InternetStatusHandler NoInternet;

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
                InternetAvailable();
            }
            else
            {
                NoInternet();
            }
            yield return new WaitForSeconds(CheckPeriodSeconds);
        }
    }

    private void HandleNoInternet()
    {
        _isActive = false;
    }

    private void HandleInternetAvailable()
    {
        _isActive = true;
    }
}
