using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallConstructor : MonoBehaviour {

    // Use this for initialization
    void Start () {
	    
        BallParametrs.start();

        GetComponent<Animator>().runtimeAnimatorController = BallParametrs.Controller;
        GetComponent<SpriteRenderer>().sprite = BallParametrs.Renderer.sprite;
    }

}
