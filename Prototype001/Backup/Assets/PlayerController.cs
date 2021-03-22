using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public GameObject player;
    public Rigidbody2D Body;
    public Slider HealthBar;

    public float maxHealth = 5f;
    public float currentHealth = 0f;

    private GameManager _gameManager;

    // Use this for initialization
    void Start () {
        Body = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        _gameManager = Object.FindObjectOfType<GameManager>();
    }

    
    // Update is called once per frame
    void Update () {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
            {
            currentHealth = currentHealth - 1f;
            HealthBar.value = currentHealth;

            if (currentHealth <= 0f)
            {
                //collision.gameObject.SetActive(false);

                _gameManager.GameOver();
            }
            // lose animation
            // game over screen ?
        }
    }
}
