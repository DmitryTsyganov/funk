using UnityEngine;
using System.Collections;

public class FireHandler : MonoBehaviour {

    Quaternion rotation;
    public Vector3 positionOffset = Vector3.zero;

    void Awake()
    {
        rotation = transform.rotation;
    }

    void Start()
    {
        if (positionOffset == Vector3.zero)
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
