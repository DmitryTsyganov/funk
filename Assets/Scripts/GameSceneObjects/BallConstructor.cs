﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallConstructor : MonoBehaviour {

    // Use this for initialization
    void Start () {
	    
        BallParametrs.start();

        GetComponent<Animator>().runtimeAnimatorController = BallParametrs.Controller;
        GetComponent<SpriteRenderer>().sprite = BallParametrs.Renderer.sprite;

        foreach (var addon in BallParametrs.Addons)
        {
            var addonInstance = Instantiate(addon.Value);
            addonInstance.transform.position =
                addonInstance.transform.position / addonInstance.transform.localScale.x * gameObject.transform.localScale.x;
            addonInstance.transform.parent = gameObject.transform;
            addonInstance.transform.localScale = Vector3.one;
            addonInstance.transform.position = gameObject.transform.position + addonInstance.transform.position;
        }
    }

}
