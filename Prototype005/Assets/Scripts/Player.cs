using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private static Player _instance = null;
    public static Player Instance
    {
        get
        {
            return _instance;
        }
    }

    Rigidbody2D rb;
    public Transform spawner;

    private float constantSpeed = 15f;
    private bool isStarted = false;
    private bool isHidden = false;
    [HideInInspector]
    public bool isGrounded = false;

    private float startTouchPosition;
    private float endTouchPosition;
    private int jumps;

    public float jumpForce;
    [HideInInspector]
    public int health = 1;
    public ParticleSystem deathEffect;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveCoroutine());
    }

    float inputTime;
    Vector2 inputPosition;
    bool isDragging = false;
    bool isPressing = false;
    bool clicked = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStarted == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPressing = true;
                inputTime = Time.time;
                inputPosition = Input.mousePosition;
                isDragging = false;
                clicked = false;
            }
            else if (Input.GetMouseButton(0))
            {
                var offset = Mathf.Max(0, Input.mousePosition.y - inputPosition.y);
                float t = Time.time - inputTime;
                float pixelScaleFactor = 1f / Screen.height * 1080;
                if (offset * pixelScaleFactor > 2)
                {
                    isDragging = true;
                }
                if (t > 0.1f && !isDragging)
                {
                    clicked = true;         
                }
            }
            else
            {
                isPressing = false;
            }

            var velocity = rb.velocity;
            velocity.x = constantSpeed * 1;

            if (clicked)
            {
                clicked = false;
                velocity.x = 0;
            }
            rb.velocity = velocity;

            CheckTouch();
        }
    }

    IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(0.55f);

        isStarted = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            isDragging = false;
            isGrounded = true;
            jumps = 1;
        }
        else
        {
            isGrounded = false;
        }
        if (collision.transform.CompareTag("Box"))
        {
            health--;
            if (health <= 0)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
                PanelController.Instance.GameOver.SetActive(true);
                gameObject.SetActive(false);
                // Destroy(gameObject);
            }
        }

        if (collision.transform.CompareTag("Barrier"))
        {
            health--;
            if (health <= 0)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
                PanelController.Instance.GameOver.SetActive(true);
                gameObject.SetActive(false);
                // Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("HideyHole"))
        {
            isHidden = true;
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (collision.tag == "Projectile") //("Projectile"))
        {
            health--;
            if (health <= 0)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
                PanelController.Instance.GameOver.SetActive(true);
                gameObject.SetActive(false);
                // Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("HideyHole"))
        {
            isHidden = false;
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

    void CheckTouch()
    {
        if (jumps > 0)
        {
            if (isDragging)
            {
                startTouchPosition = inputPosition.y;
            }
            if (!isPressing && isDragging)
            {
                isDragging = false;
                endTouchPosition = Input.mousePosition.y;
                if (endTouchPosition > startTouchPosition)
                {
                    Jump();
                    jumps--;
                }
            }
        }
    }

    void Jump()
    {
        var vel = rb.velocity;
        vel.y += jumpForce;
        rb.velocity = vel;
    }
}
