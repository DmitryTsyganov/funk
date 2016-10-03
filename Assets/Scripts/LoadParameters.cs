using UnityEngine;
using System.Collections;

public class LoadParameters : MonoBehaviour {
    
	
	void Awake () {
        Load();
	}
    void Load() {
        //BallParametrs.ballSprite =  Resources.Load<Sprite>("BallTexture/" + (PlayerPrefs.HasKey("BallSpriteName") ? PlayerPrefs.GetString("BallSpriteName"):"Default"));

    }
	
}
