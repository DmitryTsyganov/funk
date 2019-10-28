using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarHandler : MonoBehaviour
{
	public Image StarImage;
	public Animator StarAnimator;
	public AudioSource StarSound;
	private bool _isActive;
	private int _number;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetActive(bool value, int number, bool immediate)
	{
		_number = 4 - number;
		if (!value)
		{
			StarImage.color = Color.black;
		}
		else if (immediate)
		{
			StarImage.color = Color.white;
		}
		else
		{
			StartCoroutine(StarActivation());
		}
	}

	private IEnumerator StarActivation()
	{
		StarImage.color = Color.white;
		yield return new WaitForSeconds(0.4f * _number);
		StarAnimator.SetBool("Active", true);
		StarSound.Play();
	}
}
