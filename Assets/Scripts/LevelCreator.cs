using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class LevelCreator : MonoBehaviour {

    public GameObject BallPrefab;
    public GameObject BallStartPrefab;
    public GameObject BasketPrefab;
    public GameObject BrickPrefab;
    public GameObject ErrorText;
    public GameObject StarPrefab;
    public GameObject Tips;
    public GameObject SectionsMenu;

    public InputVerifyer inputVerifyer;
	[SerializeField]
	private GameObject tips;
    #if UNITY_EDITOR
    public GameObject devInterface;
    #endif
    private GameObject[] ballClones;
    private GameObject[] basketClones;
    private bool[] wasHit;
    private int basketsHitsLeft;
    private GameObject[] brickClones;
    private GameObject[] starClones;
	private string funk;
    private string defaultFunk;
    private InputField inputFieldCo;

    private FullLevel level;

	private int levelsNumber;

    // Use this for initialization
    void Start () {

        setLanguage();

        ScenesParameters.isValid = true;

        var inputFieldGo = GameObject.Find("InputField");
        inputFieldCo = inputFieldGo.GetComponent<InputField>();

        #if UNITY_EDITOR
        if (!ScenesParameters.Devmode)
        {
        #endif
            createLevelFromXml(ScenesParameters.LevelName + ScenesParameters.CurrentLevel);

            if (Saver.hasShownTraining() != 1 && ScenesParameters.Section == "linear" && 
                ScenesParameters.CurrentLevel == 1)
            {
                Tips.SetActive(true);
            }
        #if UNITY_EDITOR
        } else
        {
            devInterface = Instantiate(devInterface);
            devInterface.SetActive(true);
            if (ScenesParameters.Section == null)
            {
                throw new Exception("Entering devmode through GameScreen is obsolete, " +
                                    "use SectionsMenu Instead.");
            }
        }
        #endif
    }

    private void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        //main elements
        LanguageManager.setText("BottomMenuButtonText", LanguageManager.getLanguage().sections_menu);
        LanguageManager.setText("RunButtonText", LanguageManager.getLanguage().run);
        LanguageManager.setText("ResetButtonText", LanguageManager.getLanguage().reset);
        LanguageManager.setText("ShopText", LanguageManager.getLanguage().shop);
        LanguageManager.setText("HintButtonText", LanguageManager.getLanguage().hint);
        //LanguageManager.setText(SectionsMenu, LanguageManager.getLanguage().sections_menu);

        //buy stars
        LanguageManager.setText("ResetButtonText", LanguageManager.getLanguage().reset);

    }

    public void createLevelFromXml(string filename)
    {		
        var parser = new XMLParser();

        level = (FullLevel)parser.parse(filename);

        if (level == null) return;

        if (level.balls != null)
        {
            ballClones = new GameObject[level.balls.Length];

            for (int i = 0; i < level.balls.Length; ++i)
            {

                var ballPosition = new Vector3(level.balls[i].x, level.balls[i].y, 0f);
                ballClones[i] = Instantiate(BallPrefab, ballPosition, Quaternion.Euler(0, 0, 0));

                var ballScale = new Vector3(level.balls[i].scale, level.balls[i].scale, 1f);

                ballClones[i].transform.localScale = ballScale;

                var startPosition = ballPosition;

                GameObject ballStart = Instantiate(BallStartPrefab, startPosition, Quaternion.Euler(0, 0, 0));
                ballStart.transform.localScale = ballScale;

                //фуфло
                /*ballClones[i].GetComponent<SpriteRenderer>().sprite = ballStart.GetComponent<SpriteRenderer>().sprite;
                ballClones[i].GetComponent<Animator>().runtimeAnimatorController =
                ballStart.GetComponent<Animator>().runtimeAnimatorController;*/
                //фуфло

            }
        }

        if (level.baskets != null)
        {
            basketClones = new GameObject[level.baskets.Length];
            wasHit = new bool[level.baskets.Length];
            Array.Clear(wasHit, 0, wasHit.Length);
            basketsHitsLeft = level.baskets.Length;

            for (int i = 0; i < level.baskets.Length; i++)
            {
                var basketPosition = new Vector3(level.baskets[i].x, level.baskets[i].y, 0f);

                basketClones[i] = (GameObject)Instantiate(BasketPrefab, basketPosition,
                            Quaternion.AngleAxis(level.baskets[i].angle, Vector3.forward));

                basketClones[i].transform.localScale = new Vector3(level.baskets[i].scale, level.baskets[i].scale, 1f);
            }
        }

        if (level.obsticleBricks != null)
        {
            brickClones = new GameObject[level.obsticleBricks.Length];

            for (int i = 0; i < level.obsticleBricks.Length; i++)
            {
                var brickPosition =
                new Vector2(level.obsticleBricks[i].x, level.obsticleBricks[i].y);

                brickClones[i] = (GameObject)Instantiate(BrickPrefab, brickPosition,
                                Quaternion.AngleAxis(level.obsticleBricks[i].angle, Vector3.forward));

                brickClones[i].transform.localScale = new Vector3(level.obsticleBricks[i].scale, level.obsticleBricks[i].scale, 1f);
            }
        }

        if (level.stars != null)
        {
            starClones = new GameObject[level.stars.Length];

            for (int i = 0; i < level.stars.Length; i++)
            {
                var starPosition =
                new Vector2(level.stars[i].x, level.stars[i].y);

                starClones[i] = Instantiate(StarPrefab, starPosition,
                                Quaternion.AngleAxis(level.stars[i].angle, Vector3.forward));

                starClones[i].transform.localScale = new Vector3(level.stars[i].scale, level.stars[i].scale, 1f);
            }
        }

        funk = level.Funk;
        defaultFunk = level.DefaultFunk;

#if UNITY_EDITOR
        if (ScenesParameters.Devmode)
        {
            GameObject.Find("RequiredInputField").GetComponent<InputField>().text = funk;
            GameObject.Find("DefaultInputField").GetComponent<InputField>().text = defaultFunk;
            GameObject.Find("hintField").GetComponent<InputField>().text = level.HintText;
        }
#endif
    
        string[] args = { funk };

        inputVerifyer.setReqiredFunctions(args);
        inputVerifyer.setDefaultFunction(defaultFunk);

        inputFieldCo.keyboardType = TouchScreenKeyboardType.PhonePad;
        //inputFieldCo.text = "<color=red>" + level.Funk + "</color>";

        //inputFieldCo.text = "<size=30><color=red>" + level.Funk + "</color></size>";

        //inputFieldCo.text = level.DefaultFunk;

        var coloredText = level.DefaultFunk.Replace(funk, funk);
        //Debug.Log(coloredText);

        inputVerifyer.setPrevInput(coloredText);

        inputFieldCo.text = coloredText;

        //inputFieldCo.onValueChange.AddListener(delegate { ValueChangeCheck(); });

        var button = GameObject.Find("RunButton");
        button.GetComponent<Button>().onClick.Invoke();

		ScenesParameters.trueFunction = level.HintText;
    }

    public void resetField()
    {
        //inputFieldCo.text = "<color = red>" + level.Funk + "</color>";

        //inputFieldCo.text = "<size=30><color=red>" + level.Funk + "</color></size>";

        inputFieldCo.text = defaultFunk;

    }

    public void ValueChangeCheck()
    {
        int index = inputFieldCo.text.IndexOf(funk);

        if (index == -1)
        {
            ScenesParameters.isValid = false;
            ErrorText.SetActive(true);
        } else
        {
            ScenesParameters.isValid = true;
            ErrorText.SetActive(false);
        }
    }

    public void resetLevelObjects()
    {
        resetStars();

        #if UNITY_EDITOR
        if (ScenesParameters.Devmode)
        {
            resetBallsDevmode();
        }
        else
        {
        #endif
            resetBalls();
            resetBaskets();
        #if UNITY_EDITOR
        }
        #endif
    }

    public void resetStars()
    {
        if (starClones != null)
        {
            for (int i = 0; i < starClones.Length; ++i)
            {
                if (starClones[i] != null)
                {
                    starClones[i].SetActive(true);
                }
            }
        }

    }

    public void resetBalls()
    {
        for (int i = 0; i < ballClones.Length; ++i)
        {
            if (ScenesParameters.isValid && ballClones[i] != null)
            {
                ballClones[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                ballClones[i].GetComponent<Rigidbody2D>().angularVelocity = 0;
                ballClones[i].GetComponent<Transform>().position = new Vector3(level.balls[i].x, level.balls[i].y, 0f);
            }
        }
    }

    #if UNITY_EDITOR
    private void resetBallsDevmode()
    {
        var ballStarts = GameObject.FindGameObjectsWithTag("BallStart");
        var balls = GameObject.FindGameObjectsWithTag("Ball");

        int length = balls.Length > ballStarts.Length ? ballStarts.Length : balls.Length;

        for (int i = 0; i < length; ++i)
        {
            balls[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            balls[i].GetComponent<Rigidbody2D>().angularVelocity = 0;
            balls[i].transform.position = ballStarts[i].transform.position;
        }
    }
    #endif

    private void resetBaskets()
    {
        basketsHitsLeft = wasHit.Length;
        for (int i = 0; i < wasHit.Length; ++i)
        {
            wasHit[i] = false;
        }
    }

    public void hitBasket(GameObject basket)
    {
        #if UNITY_EDITOR
        if (ScenesParameters.Devmode) ballClones = GameObject.FindGameObjectsWithTag("Basket");
        #endif
        int index = Array.IndexOf(basketClones, basket);
        if (index != -1 && !wasHit[index])
        {
            wasHit[index] = true;
            --basketsHitsLeft;
        }
    }

    public bool IsCompleted()
    {
        return basketsHitsLeft == 0;
    }

    public int getHitStarsCount()
    {
        if (level.stars == null || level.stars.Length == 0)
        {
            return -1;
        }
    
        int starsCount = 0;

        for (int i = 0; i < starClones.Length; ++i)
        {
            if (!starClones[i].activeSelf)
            {
                ++starsCount;
            }
        }

        return starsCount;
    }
}
