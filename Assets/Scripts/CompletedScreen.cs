using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompletedScreen : MonoBehaviour {

    public GameObject CompletedPrefab;
    private static GameObject _completed;

    void Start()
    {
        _completed = CompletedPrefab;
        _completed = Instantiate(_completed);
    }

    public static GameObject getInstanse() {
        return _completed;
    }

    public static void showStars(int starCount)
    {
        showStarIfDidGet("StarBigImage", 3, starCount);
        showStarIfDidGet("StarMiddleImage", 2, starCount);
        showStarIfDidGet("StarLittleImage", 1, starCount);
    }

    public static void dontShowStars()
    {
        var gotStars = _completed.transform.FindChild("Canvas_Completed")
            .FindChild("BackgroundImage").FindChild(
            "ImageCompleted").FindChild("GotStars").gameObject;
        gotStars.SetActive(false);
    }
    
    public static void showCollectedStarsQuantity(int award)
    {
        var gotStars = _completed.transform.FindChild("Canvas_Completed")
            .FindChild("BackgroundImage").FindChild(
            "ImageCompleted").FindChild("GotStars").gameObject;

        gotStars.SetActive(true);
        GameObject.Find("StarCountText").GetComponent<Text>().text =
                            "+ " + award + " " + LanguageManager.getLanguage().stars;
    }

    private static void showStarIfDidGet(string name, int number, int starCount)
    {
        var starImage = GameObject.Find(name).GetComponent<StarHandler>();
        starImage.SetActive(starCount < number, number);
    }
}
