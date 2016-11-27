using UnityEngine;
using System.Collections;

public class StarCollisionHandler : MonoBehaviour
{
    public GameObject GatheredAnimation;
    private LevelCreator level;

	// Use this for initialization
	void Start ()
	{
	    level = GameObject.Find("Level").GetComponent<LevelCreator>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
        var anim = Instantiate(GatheredAnimation);

        anim.transform.position = gameObject.transform.position;
    }
}
