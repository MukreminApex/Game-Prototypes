using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyController : MonoBehaviour {
    SpriteRenderer sr;

    public line line;
    public GameObject FloatingTextPrefab;
    public GameObject ParticleEffect;
    public float maxHealth = 2f;
    private float currentHealth = 0f;
    public float speed = 0.5f;
    public float dmg = 3f;
    public float increaseDifRate = 10f;
    private float point = 4f;
    private float diftimer;
    float lastCollisionTime;
    bool isDead = false;
    private float revDirDur = 0.4f;
    private bool CircleCollider2D = true;
    private bool Rigidbody2D = true;

    // Use this for initialization
    void Start() {
        currentHealth = maxHealth;

        SetCountText();

        sr = GetComponent<SpriteRenderer>();

        diftimer = increaseDifRate;
    }

    // Update is called once per frame
    void Update() {
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
        else if (!isDead)
        {
            float t = (Time.time - lastCollisionTime) / revDirDur;
            var nyRetning = Mathf.Lerp(1,-1,t);
            if (nyRetning > 0 && isDead) {
                Killbill();
            }
            retning *= nyRetning;
        }
        else
        {
            retning *= 1f;
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
        if (speed < 8f)
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
            if (currentHealth > 1)
            {
                line.lineAmount--;
                Destroy(collision.gameObject);
            }

            currentHealth -= 1f;
            sr.color = new Color(255, 0, 0);

            
            if (currentHealth <= 0f)
            {
                if (isDead)
                {
                    Killbill();
                }
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
        go.GetComponent<TextMesh>().text = "+" + point.ToString();
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
