using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public GameObject impactEffect;
    public float rotationsSpeed;
    public int damage;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {

	}
    public void Shoot(Vector2 direction, Vector2 startPos)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed; 
        rb.angularVelocity = rotationsSpeed * Mathf.Sign(direction.x);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.Instance.health--;
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
