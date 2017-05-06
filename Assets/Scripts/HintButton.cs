using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintButton : MonoBehaviour
{
    public static bool PlayHintAnimation = true;

    public GameObject buyHintMenu;
    public GameObject hintScreen;
    public Text hintButtonText;
    public Text hintText;
    public Animator HintAnimator;

    private string TriggerName = "Play";

	// Use this for initialization
	void Start ()
	{
	    PlayHintAnimation = true;
	    if (!(Saver.isLevelCompletedWithStars() || Saver.isLevelComplete(ScenesParameters.CurrentLevel)) &&
	        !(ScenesParameters.Section == "linear" && ScenesParameters.CurrentLevel == 1))
	    {
	        print("started hint coroutine");
	        StartCoroutine(RemidndAboutHint());
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onHintButtonClick()
    {
        if (Saver.isHintBought() != 1)
        {
            buyHintMenu.SetActive(true);
        }
        else
        {
            hintScreen.SetActive(true);
            hintText.text = ScenesParameters.trueFunction;
            hintButtonText.text = LanguageManager.getLanguage().back;
        }
    }

    private IEnumerator RemidndAboutHint()
    {
        yield return new WaitForSeconds(45);
        while (PlayHintAnimation)
        {
            HintAnimator.SetBool(TriggerName, !HintAnimator.GetBool(TriggerName));
            yield return new WaitForSeconds(30);
        }
    }
}
