using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallConstructor : MonoBehaviour {

    public Camera cam;
	//private SpriteRenderer spriteBall;
    public CircleCollider2D ball;

    //public Image defaultImage;
    public GameObject defaultBall;

    // Use this for initialization
    void Start () {
		//spriteBall = GetComponent<SpriteRenderer>();
        if (BallParametrs.Renderer == null)
        {
            BallParametrs.setDefaultBall();
        }

        //spriteBall.sprite = BallParametrs.ballSprite;
        GetComponent<Animator>().runtimeAnimatorController = BallParametrs.Controller;
        GetComponent<SpriteRenderer>().sprite = BallParametrs.Renderer.sprite;
    }
	

}
