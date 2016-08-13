using UnityEngine;
using System.Collections;

public class StarCollisionHandler : MonoBehaviour
{
    private LevelCreator level;

	// Use this for initialization
	void Start ()
	{
	    level = GameObject.Find("Level").GetComponent<LevelCreator>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
    }
}
