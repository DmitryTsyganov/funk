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

    private bool _tryToStartPlaying = false;

    private static AudioPlayerStatic _instance;

    private void Start()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);

        StartTracks();

        //PlayMainTheme();
    }
	
	// Update is called once per frame
	void Update () {
	    TryToStartPlaying();
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

    private void StartTracks()
    {
        bool allLoaded = true;
        foreach (var track in MenuTracks)
        {
            allLoaded &= track.clip.loadState == AudioDataLoadState.Loaded;
        }
        if (allLoaded)
        {
            print("All tracks loaded, choosing random one");
            PlayMenuTracks();
        }
        else
        {
            print("Not all tracks are loaded, waiting for the first one");
            _tracks = MenuTracks;
            _tryToStartPlaying = true;
        }
    }

    private void Play(int index  = -1)
    {
        Stop();

        if (_tracks.Length == 0)
            return;

        _isOn = true;

        if (index == -1)
            index = Mathf.RoundToInt((_tracks.Length - 1) * Random.value);

        _currentTrack = _tracks[index];
        _currentTrack.Play();
        int nextIndex = index + 1 != _tracks.Length ? index + 1 : 0;

        int trackLength = Mathf.RoundToInt(_currentTrack.clip.length);

        _nextTrackSwither = StartCoroutine(PlayNextTrack(nextIndex, trackLength));
    }

    private void TryToStartPlaying()
    {
        if (_tryToStartPlaying)
        {

            for (int i = 0; i < _tracks.Length; ++i)
            {
                if (_tracks[i].clip.loadState == AudioDataLoadState.Loaded)
                {
                    print($"Track number {i} is loaded first");
                    _tryToStartPlaying = false;
                    Play(i);
                    break;
                }
            }
        }
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
