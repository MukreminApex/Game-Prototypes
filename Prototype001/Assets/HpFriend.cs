using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpFriend : MonoBehaviour {

    public GameObject ParticleEffect;

    public float maxHealth = 1f;
    private float currentHealth = 0f;
    public float speed = 7f;

    private float diftimer;
    float lastCollisionTime;
    bool isDead = false;
    private float revDirDur = 0.4f;
    private bool CircleCollider2D = true;
    private bool Rigidbody2D = true;

    SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;

        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 retning = transform.position;
        retning.Normalize();
        if (Time.time > lastCollisionTime + revDirDur)
        {
            retning *= -1;
        }
        transform.position += (Vector3)retning * Time.deltaTime * speed;

    }

    void decreaseHealth()
    {
        float calchealth = currentHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "line")
        {
            currentHealth -= 1f;
           
            if (currentHealth <= 0f)
            {
                if (ParticleEffect)
                {
                    ShowDeathParticle();
                }

                Destroy(gameObject);
            }
        }

        if (collision.transform.tag == "Player")
        {
            
            Destroy(gameObject);
        }
    }

    void ShowDeathParticle()
    {
        GameObject go = Instantiate(ParticleEffect, transform.position, Quaternion.identity) as GameObject;
        go.GetComponent<ParticleSystem>();
    }
}
