using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPaperSpinHandler : MonoBehaviour
{
	public List<Animator> Papers;

	public void Close()
	{
		SetValueForAll("Open", false);
		SetValueForAll("Close", true);
	}

	public void Open()
	{
		SetValueForAll("Close", false);
		SetValueForAll("Open", true);
	}

	private void SetValueForAll(string name, bool value)
	{
		foreach (var paper in Papers)
		{
			paper.SetBool(name, value);
		}
	}
}
