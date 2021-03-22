using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothTime;

    private Vector3 velocity;

    void Start()
    {

    }

    void Update()
    {
        if (target != null)
        {
            var endPosition = target.position + offset;
            // endPosition.y = transform.position.y;

            transform.position = Vector3.SmoothDamp(transform.position, endPosition, ref velocity, smoothTime);
        }
    }
}