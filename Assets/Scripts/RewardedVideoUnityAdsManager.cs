using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedVideoUnityAdsManager : MonoBehaviour
{

    private static RewardedVideoUnityAdsManager instance = null;

    public delegate void Reward();

    private Reward currentReward = null;

    private string zoneId = "rewardedVideo";

    public static RewardedVideoUnityAdsManager GetInstance()
    {
        if (instance == null) instance = new RewardedVideoUnityAdsManager();
        return instance;
    }

    public bool isAdReady()
    {
        return Advertisement.IsReady(zoneId);
    }

    public void ShowRewardedAd(Reward reward)
    {
        if (Advertisement.IsReady(zoneId))
        {
            currentReward = null;
            if (reward != null) currentReward = reward;
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(zoneId, options);
        }
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
                    print("No reward function provided");
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
