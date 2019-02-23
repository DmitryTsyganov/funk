using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPaperSpinHandler : MonoBehaviour
{
	public List<Animator> Papers;
	private IEnumerator deactivateSelf;
	// Hack!! we need to deactivate canvas after transition
	private const float TRANSITION_TIME = 0.7f;

	private void Start()
	{
		gameObject.SetActive(false);
	}

	public void Close()
	{
		if (deactivateSelf != null)
			StopCoroutine(deactivateSelf);
		gameObject.SetActive(true);
		SetValueForAll("Open", false);
		SetValueForAll("Close", true);
	}

	public void Open()
	{
		SetValueForAll("Close", false);
		SetValueForAll("Open", true);
		deactivateSelf = DeactivateSelf();
		StartCoroutine(deactivateSelf);
	}

	private void SetValueForAll(string name, bool value)
	{
		foreach (var paper in Papers)
		{
			paper.SetBool(name, value);
		}
	}

	private IEnumerator DeactivateSelf()
	{
		yield return new WaitForSeconds(TRANSITION_TIME);
		gameObject.SetActive(false);
	}
}
