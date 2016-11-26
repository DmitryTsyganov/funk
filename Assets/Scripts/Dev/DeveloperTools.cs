using UnityEngine;
using System.Collections;

public class DeveloperTools : MonoBehaviour {

    private bool ballIsFreezed = false;

	public void FreezeBall()
    {
        var balls = GameObject.FindGameObjectsWithTag("Ball");

	    for (int i = 0; i < balls.Length; i++)
	    {
            if (balls[i] != null)
            {
                var ball = balls[i];

                var rigidbody = ball.GetComponent<Rigidbody2D>();

                if (ballIsFreezed)
                {
                    rigidbody.constraints = RigidbodyConstraints2D.None;
                }
                else
                {
                    rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }
        }

        ballIsFreezed = !ballIsFreezed;
    }
}
