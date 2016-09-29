using System;
using UnityEngine;
using System.Collections;
using System.Globalization;
using GoogleMobileAds.Api;

public class RewardedVideoGoogleAdmobManager : MonoBehaviour
{
    private RewardBasedVideoAd rewardBasedVideo;
    private static bool isRewardInitialised = false;
    private static RewardedVideoGoogleAdmobManager instance = null;

    public RewardedVideoGoogleAdmobManager()
    {
        rewardBasedVideo = RewardBasedVideoAd.Instance;

        // RewardBasedVideoAd is a singleton, so handlers should only be registered once.

        if (!isRewardInitialised)
        {
            rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
            rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
            rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
            rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
            rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
            rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
            rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

            isRewardInitialised = true;
        }

        RequestRewardBasedVideo();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RequestRewardBasedVideo()
    {
        #if UNITY_EDITOR
            string adUnitId = "unused";
        #elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-2267489283715146/7382039118";
        #elif UNITY_IPHONE
            string adUnitId = "INSERT_AD_UNIT_HERE";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        rewardBasedVideo = RewardBasedVideoAd.Instance;

        var builder = new AdRequest.Builder();
        AdRequest request = builder.Build();
        rewardBasedVideo.LoadAd(request, adUnitId);

        print("rewardBasedVideo requested");
    }


    public void watchAdForHint()
    {
        print("watchAdForHint called");

        if (rewardBasedVideo.IsLoaded())
        {
            print("video is loaded");
            rewardBasedVideo.Show();
        }
        else
        {
            print("Video is not ready yet.");
        }
    }

    public static RewardedVideoGoogleAdmobManager GetInstance()
    {
        if (instance == null) instance = new RewardedVideoGoogleAdmobManager();
        return instance;
    }

    #region RewardBasedVideo callback handlers

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoLoaded event received.");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        /*hintText.text = ScenesParameters.trueFunction;
        hintWindow.SetActive(true);
        Saver.saveHint();
        ScoreStartText.text = Shop.StarScore.ToString();*/

        string type = args.Type;
        double amount = args.Amount;
        print("HandleRewardBasedVideoRewarded event received for " + amount.ToString(CultureInfo.InvariantCulture) + " " +
                type);
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoLeftApplication event received");
    }

    #endregion
}
