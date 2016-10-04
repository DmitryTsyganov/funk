using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompletedScreen : MonoBehaviour {

    public GameObject CompletedPrefab;
    public static GameObject Completed;

    void Start()
    {
        Completed = CompletedPrefab;
        Completed = Instantiate(Completed);

    }

    public static GameObject getInstanse() {
        return Completed;
    }

    public static void showStars(int starCount)
    {
        deactivateStarIfDidntGet("StarBigImage", 3, starCount);
        deactivateStarIfDidntGet("StarMiddleImage", 2, starCount);
        deactivateStarIfDidntGet("StarLittleImage", 1, starCount);
    }

    public static void showCollectedStarsQuantity(int award)
    {
        var gotStars = Completed.transform.FindChild("Canvas_Completed").FindChild(
                                    "Image_Completed").FindChild("GotStars").gameObject;

        gotStars.SetActive(true);
        GameObject.Find("StarCountText").GetComponent<Text>().text =
                            "+ " + award + " " + LanguageManager.getLanguage().stars;
    }

    private static void deactivateStarIfDidntGet(string name, int number, int starCount)
    {
        if (starCount < number) GameObject.Find(name).GetComponent<Image>().color = Color.black;
    }
}
