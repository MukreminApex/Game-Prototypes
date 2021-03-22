using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCamController : MonoBehaviour {

    #region Instance Fields
    //public Vector3 offset = new Vector3(0, 3, -10);
    //public Rigidbody target;
    //public Rigidbody cam;

    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    #endregion

    #region MonoBehaviour
    // Use this for initialization
    void Start () {
		
	}

    private void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -5));

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //cam.transform.LookAt(target.position);
        //cam.MovePosition(target.position + offset);
    }
    #endregion
}
