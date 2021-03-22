using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float shakeAmount = 0;

    public Camera mainCamera;

    private static PlayerController _instance;
    public static PlayerController Instance { get { return _instance; } }

    Rigidbody2D rb;
    GameObject player;
    // private float health = 5;
    private float speed = 5.0f;
    private int maxSpeed;
    private int jump = 15;

    private int canJump = 0;
    private bool isMoving;
    private bool isStarted = false;

    public Text countText;

    public GameObject jumpEffect;
    public GameObject deathEffect;

    private void Awake()
    {
           
    }
    void Start()
    {
        GameManager.Instance.followCam.target = transform;
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        countText = PanelController.Instance.Score.GetComponent<UI_Score>().scoreText;
        SetCountText();
        

        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveCoroutine());

        mainCamera = GameManager.Instance.mainCamera;
    }

    bool isPressing = false;
    private void Update()
    {
        transform.GetChild(0).GetComponent<Animator>().SetFloat("velY", rb.velocity.y);
    }

    private void FixedUpdate()
    {
        if (isStarted == true)
        {
            var newVel = rb.velocity;

            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (!isPressing)
                {
                    if (canJump > 0)
                    {
                        newVel.y = jump;
                        canJump--;

                        JumpEffect();
                    }
                    isPressing = true;
                }
            }
            else
            {
                isPressing = false;
            }

            newVel.x = speed;

            rb.velocity = newVel;
        }
    }

    IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(0.55f);

        isStarted = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Spikes") || collision.transform.CompareTag("Barrier"))
        {
            shakeAmount = 0.1f;
            InvokeRepeating("CameraShake", 0, .01f);
            Invoke("StopShaking", 0.3f);

            PanelController.Instance.GameOver.SetActive(true);
            DeathEffect();
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Coin")
        {
            Destroy(collision.gameObject);
            GameManager.count++;
            SetCountText();
        }
    }

    private void JumpEffect()
    {
        GameObject tmpParticles = (GameObject)Instantiate(jumpEffect, transform.position, Quaternion.identity);
        tmpParticles.transform.rotation = Quaternion.Euler(0, 0, -200);
        Destroy(tmpParticles, 3f);
    }
    
    private void DeathEffect()
    {
        GameObject tmpParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        tmpParticles.transform.rotation = Quaternion.Euler(-90, 0, 0);
        Destroy(tmpParticles, 3f);
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

    void SetCountText()
    {
        countText.text = "Coins: " + GameManager.count.ToString();
    }
}
