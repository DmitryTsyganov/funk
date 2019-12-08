using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnIOS : MonoBehaviour {

	// Use this for initialization
	private void Awake()
	{
#if UNITY_IOS
		Destroy(gameObject);
#endif
	}
}
