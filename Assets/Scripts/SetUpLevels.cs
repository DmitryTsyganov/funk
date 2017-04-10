using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.UI;

public class SetUpLevels : MonoBehaviour {

	public levelElement LevelElementPrefab;
    public ScrollRect LevelScrollRect;
    
	void Start () {
		LoadLevels ();
    }

	void LoadLevels(){
		float count =  Convert.ToInt32(Resources.Load<TextAsset>(
                    "Levels" + "/" + ScenesParameters.Section + "/" + "config").text);

	    bool isFirstNotCompletedLevel = true;

	    float position = 0;

		for (int i = 1; i <= count; i++) {
			CreateLevelElement(i);
		    if (isFirstNotCompletedLevel && !Saver.isLevelCompletedWithStars(i) && !Saver.isLevelComplete(i))
		    {
		        isFirstNotCompletedLevel = false;
		        position = 1f - Mathf.Ceil(i / 2f) / Mathf.Ceil(count / 2f);
		        if (position < 0.15) position = 0;
		        if (position > 0.15 && position < 0.5) position *= 0.85f;
		        if (position > 0.5f) position *= 1.2f;
		        print($"New position is {position}, current position is" +
		              $" {LevelScrollRect.verticalNormalizedPosition}");
		    }
		}
	    LevelScrollRect.verticalNormalizedPosition = position;
	}

    private void Update()
    {
        
    }

    void CreateLevelElement(int index){
		Transform element = Instantiate (LevelElementPrefab).transform;
		element.SetParent (transform);
		element.localScale = Vector3.one;
		element.gameObject.GetComponent<levelElement>().SetLevelIndex(index);
	}


}
