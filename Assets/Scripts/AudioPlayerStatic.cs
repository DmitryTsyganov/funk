using UnityEngine;
using System.Collections;

public class AudioPlayerStatic : MonoBehaviour
{
    public AudioSource mainTheme;
    public AudioSource buttonSFX;

    private static AudioPlayerStatic instance = null;

	// Use this for initialization
	void Start () {
        

    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        GetInstance()
            .mainTheme
            .Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public static AudioPlayerStatic GetInstance()
    {
        return instance;
    }
}
