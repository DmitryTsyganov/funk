using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PopUpHandler : MonoBehaviour
{

	public GameObject PromptImage;
	public Animator PromptImageAnimator;
	private const int OpenAnimationsNumber = 3;
	private const int CloseAnimationsNumber = 4;
	private const int NoAnimation = -1;

	private bool _doDestroy;

	private readonly TransformHelper _transformHelper = new TransformHelper();
	
	private enum States
	{
		Opening,
		Opened,
		Closing
	}
	private States _currentState = States.Opening;

	private void Awake()
	{
		_transformHelper.SaveTransformState(PromptImage);
	}

	private void Update()
	{
		HandleState();
	}

	private void HandleState()
	{
		switch (_currentState)
		{
			case States.Opening:
				if (PromptImageAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle2"))
				{
					PromptImageAnimator.enabled = false;
					_transformHelper.RestoreTransformState(PromptImage);
					_currentState = States.Opened;
				}
				break;
		}
	}

	private void OnEnable()
	{
		_currentState = States.Opening;
		PromptImageAnimator.Rebind();
		PromptImageAnimator.SetInteger("Open", Random.Range(0, OpenAnimationsNumber));
	}

	public void Close(bool doDestroy)
	{
		PromptImageAnimator.enabled = true;
		PromptImageAnimator.SetInteger("Open", NoAnimation);
		PromptImageAnimator.SetInteger("Close", Random.Range(0, CloseAnimationsNumber));
		_doDestroy = doDestroy;
		_currentState = States.Closing;
		if (gameObject.activeSelf)
			StartCoroutine(SetInactive());
	}

	private IEnumerator SetInactive()
	{
		yield return new WaitForSeconds(0.35f);
		PromptImageAnimator.SetInteger("Close", NoAnimation);
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

class TransformHelper
{
	private Vector3 _initialPosition;
	private Quaternion _initialRotation;
	private Vector3 _initialScale;
	private float _left;
	private float _right;
	private float _bottom;
	private float _top;

	public void SaveTransformState(GameObject obj)
	{
		_initialPosition = obj.transform.position;
		_initialRotation = obj.transform.rotation;
		var rect = obj.GetComponent<RectTransform>();
		_left = rect.offsetMin.x;
		_bottom = rect.offsetMin.y;
		_right = rect.offsetMax.x;
		_top = rect.offsetMax.y;
		_initialScale = obj.gameObject.transform.localScale;
	}

	public void RestoreTransformState(GameObject obj)
	{
		obj.transform.position = _initialPosition;
		obj.transform.rotation = _initialRotation;
		obj.transform.localScale = _initialScale;
		var rect = obj.GetComponent<RectTransform>();
		rect.offsetMin = new Vector2(_left, _bottom);
		rect.offsetMax = new Vector2(_right, _top);
	}
}

