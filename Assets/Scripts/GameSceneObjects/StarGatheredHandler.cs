using UnityEngine;
using System.Collections;

public class StarGatheredHandler : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(PlayAnimation());
	    GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private IEnumerator PlayAnimation()
    {
        yield return new WaitForSecondsRealtime(1.15f);
        Destroy(gameObject);
        yield return null;
    }
}
