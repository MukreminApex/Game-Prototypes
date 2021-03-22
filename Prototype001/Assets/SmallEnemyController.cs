using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyController : MonoBehaviour {
    SpriteRenderer sr;

    public GameObject FloatingTextPrefab;
    public GameObject ParticleEffect;
    public float maxHealth = 1f;
    private float currentHealth = 0f;
    public float speed = 8f;
    public float dmg = 0.25f;
    public float increaseDifRate = 10f;

    private float diftimer;
    float lastCollisionTime;
    bool isDead = false;
    private float revDirDur = 0.4f;
    private bool CircleCollider2D = true;
    private bool Rigidbody2D = true;


    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;

        SetCountText();

        sr = GetComponent<SpriteRenderer>();

        diftimer = increaseDifRate;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 retning = transform.position;
        retning.Normalize();
        if (Time.time > lastCollisionTime + revDirDur)
        {
            if (isDead)
            {
                Killbill();
            }
            retning *= -1;
        }
        transform.position += (Vector3)retning * Time.deltaTime * speed;

        if (Time.time > diftimer)
        {
            IncDif();
            diftimer = Time.time + increaseDifRate;
        }
    }

    void IncDif()
    {
        if (speed < 10f)
        {
            speed += 0.25f;
        }

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
                isDead = true;
            }
            lastCollisionTime = Time.time;
        }

        if (collision.transform.tag == "Player")
        {
            Destroy(gameObject);
        }

    }

    void ShowFloatingText()
    {
        GameObject go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity) as GameObject;
        go.GetComponent<TextMesh>().text = "+" + maxHealth.ToString();
    }

    void ShowDeathParticle()
    {
        GameObject go = Instantiate(ParticleEffect, transform.position, Quaternion.identity) as GameObject;
        go.GetComponent<ParticleSystem>();
    }

    void SetCountText()
    {
        CanvasController.Instance.count.text = "Score: " + CanvasController.Instance.countText.ToString();
    }

    void Killbill()
    {
        if (FloatingTextPrefab)
        {
            ShowFloatingText();
        }

        if (ParticleEffect)
        {
            ShowDeathParticle();
        }
        CircleCollider2D = false;
        Rigidbody2D = false;

        CanvasController.Instance.countText += 4;
        SetCountText();

        Destroy(gameObject);
    }
}
