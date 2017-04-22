using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yhandler : MonoBehaviour
{
    public CaretHandler Handler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        Handler.PlaceCaret(0);
    }
}
