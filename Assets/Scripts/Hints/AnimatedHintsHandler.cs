using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedHintsHandler : MonoBehaviour {

    public List<KeyAnimatedHintPair> animatedHints;
    public GameObject HintWrap;
    private Dictionary<string, GameObject> _animatedHints = new Dictionary<string, GameObject>();

    // Use this for initialization
    void Start () {
        InitAnimatedHints();

        var key = ScenesParameters.Section + "_" + ScenesParameters.CurrentLevel;
        if (_animatedHints.ContainsKey(key))
        {
            var hint = Instantiate(_animatedHints[key]);
            hint.transform.position = new Vector3(0, 0, 0);
            hint.transform.SetParent(HintWrap.transform, false);
        } else
        {
            Destroy(gameObject);
        }
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
