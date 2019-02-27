using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedHintsHandler : MonoBehaviour {

    public List<KeyAnimatedHintPair> animatedHints;
    public GameObject HintWrap;
    public GameObject BackGroundImage;
    public GameObject InfoButton;
    
    private Animator animator;
    private Dictionary<string, GameObject> _animatedHints = new Dictionary<string, GameObject>();

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        InitAnimatedHints();

        var key = ScenesParameters.Section + "_" + ScenesParameters.CurrentLevel;
        if (_animatedHints.ContainsKey(key))
        {
            var hint = Instantiate(_animatedHints[key]);
            hint.transform.position = new Vector3(0, 0, 0);
            hint.transform.SetParent(HintWrap.transform, false);
        } else
        {
            Destroy(InfoButton);
            Destroy(gameObject);
        }
	}

    public void StartClosingAnimation()
    {
        BackGroundImage.SetActive(false);
        animator.SetBool("Closing", true);
    }

    public void Close()
    {
        animator.SetBool("Closing", false);
        gameObject.SetActive(false);
        InfoButton.SetActive(true);
    }

    public void ShowAnimatedHint()
    {
        gameObject.SetActive(true);
        BackGroundImage.SetActive(true);
        InfoButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitAnimatedHints()
    {
        foreach (var hint in animatedHints)
        {
            _animatedHints[hint.key] = hint.animatedHint;
        }
    }
}

[System.Serializable]
public class KeyAnimatedHintPair
{
    public string key;
    public GameObject animatedHint;
}
