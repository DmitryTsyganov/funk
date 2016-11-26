using UnityEngine;
using System.Collections;

public class BrikConstructor : MonoBehaviour {

    public Camera cam;

    public BoxCollider2D brick;

    private const float brickScale = 0.6f;

    // Use this for initialization
    void Start () {
        var renderer = (SpriteRenderer)gameObject.GetComponent<SpriteRenderer>();

        var brickSize = new Vector2(renderer.sprite.bounds.size.x,
                                    renderer.sprite.bounds.size.y);

        brick.size = brickSize;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
