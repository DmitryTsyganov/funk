using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class RewardedVideoUnityAdsManager
{

    private static RewardedVideoUnityAdsManager instance = null;

    public delegate void Reward();

    private Reward currentReward = null;

    public const int MidLevelVideoInterval = 5;

    private const string rewardeVideoZoneId = "rewardedVideo";
    private const string videoZoneId = "video";

    public static RewardedVideoUnityAdsManager GetInstance()
    {
        if (instance == null) instance = new RewardedVideoUnityAdsManager();
        return instance;
    }

    public bool isAdReady()
    {
        return Advertisement.IsReady(rewardeVideoZoneId);
    }

    public void ShowRewardedAd(Reward reward)
    {
        if (Advertisement.IsReady(rewardeVideoZoneId))
        {
            currentReward = null;
            if (reward != null) currentReward = reward;
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(rewardeVideoZoneId, options);
        }
    }

    public bool ShowVideo()
    {
        if (Advertisement.IsReady(videoZoneId))
        {
            Debug.Log("showing video");
            Debug.Log(ScenesParameters.LevelCompletedInSession);
            ++ScenesParameters.LevelCompletedInSession;
            var options = new ShowOptions { resultCallback = HandleShowVideo };
            Advertisement.Show(videoZoneId, options);
            return true;
        }
        return false;
    }

    private void HandleShowVideo(ShowResult result)
    {
        SceneManager.LoadScene(3);
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                if (currentReward != null)
                {
                    currentReward();
                }
                else
                {
                    Debug.Log("No reward function provided");
                }
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}
