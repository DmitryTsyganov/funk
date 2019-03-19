using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class DeactivateTimeout : MonoBehaviour {
	
	public int Timeout;
	public UnityEvent OnDeactivate;

	private Coroutine _deactivationByTimeout;

	public void Stop()
	{
		StopCoroutine(_deactivationByTimeout);
	}

	private void OnEnable()
	{
		_deactivationByTimeout = StartCoroutine(DeactivateAfterTimeout());
	}

	private void OnDisable()
	{
		Stop();
	}

	IEnumerator DeactivateAfterTimeout()
	{
		yield return new WaitForSeconds(Timeout);
		OnDeactivate.Invoke();
		yield return null;
	}
}
