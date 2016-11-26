using UnityEngine;
using System.Collections;

public class ButtonSoundHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SoundEffect2()
    {
        AudioPlayerStatic.GetInstance().PlayRandomButtonSound();
    }
}
