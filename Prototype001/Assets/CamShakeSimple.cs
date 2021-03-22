using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShakeSimple : MonoBehaviour {

    Vector3 originalCameraPosition = new Vector3(0, 0, -10);

    float shakeAmount = 0;

    public Camera mainCamera;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "HpFriend" && collision.transform.tag != "line")
        {
            shakeAmount = 0.1f;
            InvokeRepeating("CameraShake", 0, .01f);
            Invoke("StopShaking", 0.3f);
        }
        
    }

    void CameraShake()
    {
        if (shakeAmount > 0)
        {
            float quakeAmount = Random.value * shakeAmount * 2 - shakeAmount;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmount;
            pp.x += Random.value * 0.01f;
            pp.z = -10f;
            mainCamera.transform.position = pp;
        }
    }
    
    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
