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

    public void ShowStars(int starCount, bool immediate)
    {
        if(!GotStars.activeSelf)
            GotStars.SetActive(true);
        StarBigImage.SetActive(starCount >= 3, 3, immediate);
        StarMiddleImage.SetActive(starCount >= 2, 2, immediate);
        StarLittleImage.SetActive(starCount >= 1, 1, immediate);
    }

    public void DisableText()
    {
        StarCountText.enabled = false;
    }
    
    public void ShowCollectedStarsQuantity(int award)
    {
        if (!GotStars.activeSelf)
            GotStars.SetActive(true);
        if (!StarCountText.enabled)
            StarCountText.enabled = true;
            
        StarCountText.text = "+ " + award + " " + LanguageManager.getLanguage().stars;
    }
}
