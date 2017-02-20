using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoadSaveHelperDev : MonoBehaviour
{
    public LevelCreator Creator;
    public InputField LevelNumber;

    private static readonly string[] _tagsForRemoving = { "Ball", "Basket", "TriangleObsticle", "Star", "BallStart" };

	// Use this for initialization
	void Start ()
	{
	    Creator = GameObject.Find("Level").GetComponent<LevelCreator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel()
    {
        DestroyAllLevelObjects();
        Creator.createLevelFromXml(ScenesParameters.LevelName + LevelNumber.text);
    }

    public void SaveLevel()
    {
        int number;
        if (Int32.TryParse(LevelNumber.text, out number))
        {
            Creator.resetStars();
            var parser = new XMLParser();
            parser.makeLevelFromCurrentState(number);
        }
    }

    private void DestroyAllLevelObjects()
    {
        Creator.resetStars();
        foreach (var currentTag in _tagsForRemoving)
        {
            var objects = GameObject.FindGameObjectsWithTag(currentTag);
            foreach (var obj in objects)
            {
                Destroy(obj);
            }
        }
    }
}
