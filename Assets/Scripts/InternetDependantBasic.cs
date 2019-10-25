using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InternetDependantBasic : MonoBehaviour
{
    private const float CheckPeriodSeconds = 3f;
    private const string ReachabilityUrl = "https://funk-backend.herokuapp.com/check";
    private const string ExpectedResponse = "available";

    protected delegate void InternetStatusHandler();
    protected bool _isActive { get; private set; }

    protected void DoStart()
    {
        _isActive = false;

        InternetAvailable += HandleInternetAvailable;
        NoInternet += HandleNoInternet;

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
            bool isEndpointsReachable = false;
            bool isInternetAvailable = Application.internetReachability != NetworkReachability.NotReachable;
            // reachability can be true if connected to Wifi hotspot with no actual internet access
            if (isInternetAvailable)
            {
                using (WWW www = new WWW(ReachabilityUrl))
                {
                    yield return www;
                    isEndpointsReachable = www.text == ExpectedResponse;
                }
            }
            
            if (isEndpointsReachable)
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
