using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAdsTest : MonoBehaviour
{
    private string advertisingID;

    void Start()
    {
        getInfo();
    }

    void OnGUI()
    {
        GUI.TextField(new Rect(10, 10, 450, 150), advertisingID);

        /*Rect buttonRect = new Rect(10, 10, 150, 50);
        string buttonText = Advertisement.IsReady("rewardedVideo") ? "Show Ad" : "Waiting...";
        

        if (GUI.Button(buttonRect, buttonText))
        {
            ShowRewardedAd();
        }*/
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    public void getInfo()
    {

        AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass client = new AndroidJavaClass("com.google.android.gms.ads.identifier.AdvertisingIdClient");
        AndroidJavaObject adInfo = client.CallStatic<AndroidJavaObject>("getAdvertisingIdInfo", currentActivity);

        advertisingID = adInfo.Call<string>("getId").ToString();
        print(advertisingID);
    }
}
