using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myPlayerController : MonoBehaviour
{
    #region Instance Fields

    private Rigidbody rb;
    private int count;
    private GameManager _gameManager;
    private GameManager _hiEnd;
    private float _time;
    private PlatformManager _platMan;

    public GameObject Player;

    public GameObject ParticleEffect;

    public Slider powerSlider;
    public Image _image;
    public Color startColor;
    public Color endColor;
    public Color beginSlider;
    public Color endSlider;
    public Color startPlane;
    public Color endPlane;
    public Color startObst;
    public Color endObst;

    Material _material;
    bool isFilling;
    bool isEmptying;
    bool isFull;
    bool isPickingUp;

    float colTime = -0.75f;

    public float maxSpeed;
    public float speed;
    public float startSpeed = 5;
    public float jump;
    public Text countText;
    public int startPower = 0;
    public int fullPower = 100;
    public int currentPower;
    public int coin = 1;
    public float minX = -2.5f, maxX = 2.5f;

    Vector3 dir;

    #endregion

    #region MonoBehaviour
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        currentPower = startPower;
        _gameManager = Object.FindObjectOfType<GameManager>();
        _hiEnd = Object.FindObjectOfType<GameManager>();
        _material = GetComponent<Renderer>().material;
        _platMan = Object.FindObjectOfType<PlatformManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = currentPower;
        t /= fullPower;
        Color currentColor = Color.Lerp(startColor, endColor, t);
        _material.color = currentColor;

        float c = currentPower;
        c /= fullPower;
        Color nowColor = Color.Lerp(beginSlider, endSlider, c);
        _image.color = nowColor;

        float m = currentPower;
        m /= fullPower;
        Color newColor = Color.Lerp(startPlane, endPlane, m);
        _platMan.planeCol = newColor;

        float o = currentPower;
        o /= fullPower;
        Color neuColor = Color.Lerp(startObst, endObst, o);
        _platMan.obstCol = neuColor;

        //// in Update(), instead of FixedUpdate() to prevent glitching through platform
        //Vector3 clampedPos = transform.position;

        //clampedPos.x = Mathf.Clamp(transform.position.x, -2.3f, 2.3f);
        //transform.position = clampedPos;

        Vector3 currentPosition = transform.position;
        currentPosition.x =
            Mathf.Clamp(currentPosition.x, minX, maxX);
        transform.position = currentPosition;
    }

    private void FixedUpdate()
    {
        var constantPos = rb.position;
        var vel = rb.velocity;

        if (constantPos.y < 0.25f)
        {
            constantPos.y = 0.25f;
            if (vel.y < 0) vel.y = 0.25f;
        }

        float timeSinceCol = Time.time - colTime;

        rb.position = constantPos;

        if (timeSinceCol > 0.75f)
        {
            vel.z = speed;
            rb.velocity = vel;
        }
        else
        {
            //dir = (transform.position - rb.position).normalized;
            //dir.y = 0;
            rb.velocity = norm * 3;
        }


        if (Input.GetMouseButton(0))
        {
            Move(true);
        }
    }
    #endregion

    #region Methods
    private void Move(bool direction)
    {
        Plane p = new Plane(Vector3.back, transform.position);
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distToHit = 0;
        var mousPos = Vector3.zero;
        if (p.Raycast(r, out distToHit))
        {
            mousPos = r.GetPoint(distToHit);
        }

        //if ()
        //{
            var velocity = transform.position.x - mousPos.x;
            var ballVel = rb.velocity;

            ballVel.x = velocity * speed;
            ballVel.x *= -1;
            var newBallPos = transform.position.x - ballVel.x * Time.fixedDeltaTime;

            rb.velocity = ballVel;
        //}
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.transform.tag == "Coin")
        {
            Destroy(collision.gameObject);
            count = count + 1;
            SetCountText();
            PickUp();
            ShowDeathParticle();
        }    
    }

    void ShowDeathParticle()
    {
        GameObject go = Instantiate(ParticleEffect, transform.position, Quaternion.identity) as GameObject;
        go.GetComponent<ParticleSystem>();
    }

    Vector3 norm; 

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Obstacle") && currentPower >= 1)
        {
            currentPower = 0;
            powerSlider.value = currentPower;
            speed = startSpeed;
            isFull = false;

            colTime = Time.time;
            norm = col.contacts[0].normal;

            //dir = (transform.position - rb.position).normalized;
            //rb.velocity = -dir * 10;
            //rb.velocity = Vector3.zero;

            //var nowPos = rb.position.z;
            //nowPos = -nowPos * 10;
            //nowPos = rb.position.z;
        }
        else if (col.collider.CompareTag("Obstacle") && currentPower <= 0)
        {
            _gameManager.GameOver();
            _hiEnd.HiEnd();
        }
    }

    public void PickUp()
    {
        isPickingUp = true;
        if (currentPower <= fullPower)
        {
            currentPower += coin; // amount of coins, maybe static 1?
            powerSlider.value = currentPower;
            speed += 0.1f;
        } 
        else if (currentPower >=  fullPower)// full power?
        {
            Full(); // full speed? colorful etc.
        }
    }

    void Full()
    {
        if (!isFull)
        {
            isFull = true;

            speed = 35; // change color and speed here maybe?
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }

    #endregion
}

