using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform followTarget;
    public Vector3 targetOffset;
    public float moveSpeed = 2f;

    private Transform myTransform;

	// Use this for initialization
	void Start ()
    {
        myTransform = transform;
	}

    public void SetTarget(Transform aTransform)
    {
        followTarget = aTransform;
    }

    void LateUpdate()
    {
        myTransform.position = Vector3.Lerp(myTransform.position, followTarget.position + targetOffset, moveSpeed * Time.deltaTime);
    }
}
