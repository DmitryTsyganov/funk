using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompletedScreen : MonoBehaviour
{
    public StarHandler StarBigImage;
    public StarHandler StarMiddleImage;
    public StarHandler StarLittleImage;

    public GameObject GotStars;

    public Text StarCountText;

    public void ShowStars(int starCount)
    {
        StarBigImage.SetActive(starCount < 3, 3);
        StarMiddleImage.SetActive(starCount < 2, 2);
        StarLittleImage.SetActive(starCount < 1, 1);
    }

    public void DontShowStars()
    {
        GotStars.SetActive(false);
    }
    
    public void ShowCollectedStarsQuantity(int award)
    {
        GotStars.SetActive(true);
        StarCountText.text = "+ " + award + " " + LanguageManager.getLanguage().stars;
    }
}
