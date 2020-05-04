using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var worldScreenHeight = Camera.main.orthographicSize * 2.0;
		var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		float scale = GetComponent<RectTransform>().rect.size.x / (float)worldScreenWidth;
		Debug.Log("Scale is " + scale);
		Camera.main.orthographicSize *= scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
