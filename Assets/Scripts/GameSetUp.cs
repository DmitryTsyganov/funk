using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameSetUp : MonoBehaviour {

    public BoxCollider2D topWall/* = new BoxCollider2D()*/;
    public BoxCollider2D bottomWall /*= new BoxCollider2D()*/;
    public BoxCollider2D leftWall /*= new BoxCollider2D()*/;
    public BoxCollider2D rightWall /*= new BoxCollider2D()*/;

    const float wallThickness = 1f;


    // Use this for initialization
    void Start ()
    {
        var mainCam = Camera.main;
        topWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, wallThickness);
        topWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).y * -1 + wallThickness / 2);

        bottomWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).y + wallThickness / 2 * -1);

        rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).x * -1 + wallThickness / 2, 0f);

        leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset =  new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).x + wallThickness / 2 * -1, 0f);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
