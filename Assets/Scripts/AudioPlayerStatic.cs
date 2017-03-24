using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioPlayerStatic : MonoBehaviour
{
    public AudioSource MainTheme;
    public AudioSource[] ButtonSFX;

    public AudioSource[] MenuTracks;
    public AudioSource[] GameTracks;

    private AudioSource[] _tracks;
    private Coroutine _nextTrackSwither;

    private AudioSource _currentTrack;
    private bool _isOn;

    private static AudioPlayerStatic _instance;

	// Use this for initialization
	void Start () {
        

    }

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        PlayMenuTracks();
        //PlayMainTheme();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public static AudioPlayerStatic GetInstance()
    {
        return _instance;
    }

    public void PlayRandomButtonSound()
    {
        ButtonSFX[Mathf.RoundToInt((ButtonSFX.Length -1) * Random.value)].Play();
    }

    public void PlayMenuTracks()
    {
        _tracks = MenuTracks;
        Play();
    }

    public void PlayGameTracks()
    {
        _tracks = GameTracks;
        Play();
    }

    public void Stop()
    {
        if (_currentTrack != null)
        {
            _currentTrack.Stop();
            _currentTrack = null;
        }

        if (_nextTrackSwither != null)
        {
            StopCoroutine(_nextTrackSwither);
            _nextTrackSwither = null;
        }

        _isOn = false;
    }

    private void Play(int index  = -1)
    {
        Stop();

        _isOn = true;

        if (index == -1)
            index = Mathf.RoundToInt((_tracks.Length - 1) * Random.value);

        _currentTrack = _tracks[index];
        _currentTrack.Play();
        int nextIndex = index + 1 != _tracks.Length ? index + 1 : 0;

        int trackLength = Mathf.RoundToInt(_currentTrack.clip.length);

        print("Track length " + trackLength);

        _nextTrackSwither = StartCoroutine(PlayNextTrack(nextIndex, trackLength));
    }

    private IEnumerator PlayNextTrack(int nextTrack, int seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (_isOn)
            Play(nextTrack);
    }

    private void PlayMainTheme()
    {
        GetInstance().MainTheme.Play();
    }
}
