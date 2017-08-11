using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpHandler : MonoBehaviour {

	public Animator PromptImage;
	private const int OpenAnimationsNumber = 3;
	private const int CloseAnimationsNumber = 4;
	private const int NoAnimation = -1;

	private bool _doDestroy;

	private void OnEnable()
	{
		PromptImage.Rebind();
		PromptImage.SetInteger("Open", Random.Range(0, OpenAnimationsNumber));
	}

	public void Close(bool doDestroy)
	{
		PromptImage.SetInteger("Open", NoAnimation);
		PromptImage.SetInteger("Close", Random.Range(0, CloseAnimationsNumber));
		_doDestroy = doDestroy;
		if (gameObject.activeSelf)
			StartCoroutine(SetInactive());
	}

	private IEnumerator SetInactive()
	{
		yield return new WaitForSeconds(0.35f);
		PromptImage.SetInteger("Close", NoAnimation);
		if (_doDestroy)
		{
			Destroy(gameObject);
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
}
