using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour {

    float shakeAmount = 0;

    public Camera mainCamera;
    public GameObject landingEffect;
    public GameObject landingEffectWhite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            shakeAmount = 0.1f;
            InvokeRepeating("CameraShake", 0, .01f);
            Invoke("StopShaking", 0.3f);
            LandingEffect();
        }
    }

    void CameraShake()
    {
        if (shakeAmount > 0)
        {
            float quakeAmount = Random.value * shakeAmount * 5 - shakeAmount;
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
    }

    private void LandingEffect()
    {
        landingEffect.SetActive(true);
        landingEffectWhite.SetActive(true);
    }




    // Use this for initialization
    void Start () {
        mainCamera = GameManager.Instance.mainCamera;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
