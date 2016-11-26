using UnityEngine;

public class PositionHandler : MonoBehaviour {

    private const float xDef = -1.7f;
    private const float yDef = 3.8f;

    private GameObject ball;
    private SpriteRenderer ballSprite;
    private Rigidbody2D ballBody;
    private Transform ballTransform;

    // Use this for initialization
    void Start () {
        ball = GameObject.Find("Ball");
        ballTransform = ball.GetComponent<Transform>();
        ballBody = ball.GetComponent<Rigidbody2D>();
		ballSprite = ball.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setPosition()
    {
        ballBody.velocity = new Vector2(0, 0);
        ballBody.angularVelocity = 0;
        ballTransform.position = new Vector3(xDef, yDef, ballTransform.position.z);
		//ballSprite.sprite = BallParametrs.ballSprite;
    }
}
