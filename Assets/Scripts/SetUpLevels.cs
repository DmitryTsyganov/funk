using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.UI;

public class SetUpLevels : MonoBehaviour {

	public levelElement LevelElementPrefab;
   
    
	void Start () {
		LoadLevels ();
    }
	void LoadLevels(){
		int count =  Convert.ToInt32(Resources.Load<TextAsset> (
                    "Levels" + "/" + ScenesParameters.Section + "/" + "config").text);
		for (int i = 1; i <= count; i++) {
			CreateLevelElement (i);
		}
	}
	void CreateLevelElement(int index){
		Transform element = Instantiate (LevelElementPrefab).transform;
		element.SetParent (transform);
		element.localScale = Vector3.one;
		element.gameObject.GetComponent<levelElement> ().SetLevelIndex (index);
	}


}
