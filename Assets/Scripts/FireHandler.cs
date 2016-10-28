using UnityEngine;
using System.Collections;

public class FireHandler : MonoBehaviour {

    Quaternion rotation;
    private Vector3 positionOffset;

    void Awake()
    {
        rotation = transform.rotation;
    }

    void Start()
    {
        positionOffset = transform.position - transform.parent.position;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
        transform.position = transform.parent.position + positionOffset;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
