using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    float shakeAmount = 0;
    public Camera mainCamera;

    public ParticleSystem platformEffect;
    public ParticleSystem platformBounce;
    public ParticleSystem platformDestroy;
    public ParticleSystem blackDestroy;
    public ParticleSystem platformMoving;

	// Use this for initialization
	void Start () {

        mainCamera = GameManager.Instance.mainCamera;

    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y < -100)
        {
            OutOfBounds();
        }
	}

    void OutOfBounds()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            ParticleSystem tmpParticles = (ParticleSystem)Instantiate(platformEffect, transform.position, Quaternion.identity);
            Destroy(tmpParticles, 3f);
        }
        if (collision.transform.CompareTag("BouncePlatform"))
        {
            ParticleSystem tmpParticles = (ParticleSystem)Instantiate(platformBounce, transform.position, Quaternion.identity);
            Destroy(tmpParticles, 3f);

            GameManager.Instance.camController.StartCameraShake(0.15f, 0.3f);
        }
        if (collision.transform.CompareTag("PlatformDestroy"))
        {
            ParticleSystem tmpParticles = (ParticleSystem)Instantiate(platformDestroy, transform.position, Quaternion.identity);
            Destroy(tmpParticles, 3f);
            ParticleSystem tmpParticless = (ParticleSystem)Instantiate(blackDestroy, transform.position, Quaternion.identity);
            Destroy(tmpParticless, 3f);

            Destroy(gameObject);

            GameManager.Instance.camController.StartCameraShake(0.5f, 0.3f);
        }
        if (collision.transform.CompareTag("MovingPlatform"))
        {
            ParticleSystem tmpParticles = (ParticleSystem)Instantiate(platformMoving, transform.position, Quaternion.identity);
            Destroy(tmpParticles, 3f);
        }
    }
}
 