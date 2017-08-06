using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class TransitionManagerHandler : MonoBehaviour
{
	public List<TransitionPaperSpinHandler> Transitions;

	private TransitionPaperSpinHandler _currentTransition;
	private bool _canOpen = false;

	private static TransitionManagerHandler _instance;

	public static TransitionManagerHandler GetInstance()
	{
		return _instance;
	}
	
	// Use this for initialization
	void Start () {
		if (_instance != null)
		{
			Destroy(gameObject);
			return;
		}
		_instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void StartTransition(int level)
	{
		StartCoroutine(Close(level));
	} 
	
	void Open()
	{
		print("Open");
		StartCoroutine(TryOpening());
	}

	IEnumerator Close(int level)
	{
		var index = Transitions.Count != 0 ? Mathf.RoundToInt((Transitions.Count - 1) * Random.value) : 0;
		_currentTransition = Transitions[index];
		_currentTransition.Close();
		yield return new WaitForSeconds(1);
		SceneManager.sceneLoaded += SetCanOpen;
		SceneManager.LoadSceneAsync(level);
		Open();
	}


	void SetCanOpen(Scene scene, LoadSceneMode mode)
	{
		_canOpen = true;
	}

	IEnumerator TryOpening()
	{
		while (true)
		{
			if (_canOpen)
			{
				_currentTransition.Open();
				_canOpen = false;
				SceneManager.sceneLoaded -= SetCanOpen;
				yield break;
			}
			else
			{
				yield return null;
			}
		}
	}
}
