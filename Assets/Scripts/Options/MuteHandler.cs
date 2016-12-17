using UnityEngine;
using System.Collections;

public class MuteHandler : MonoBehaviour
{

    public GameObject Cross;
    private static bool isSoundOn = true;

	// Use this for initialization
	void Start ()
    {
        Cross.SetActive(!isSoundOn);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Click()
    {
        isSoundOn = !isSoundOn;
        AudioListener.volume = isSoundOn ? 1 : 0;
        Cross.SetActive(!isSoundOn);
        Saver.turnSound(isSoundOn);
    }

    public static void turnSound(bool on)
    {
        isSoundOn = on;
        AudioListener.volume = isSoundOn ? 1 : 0;
    }
}
