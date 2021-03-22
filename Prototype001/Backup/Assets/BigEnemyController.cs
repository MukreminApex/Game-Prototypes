using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyController : MonoBehaviour {
    SpriteRenderer sr;

    public GameObject FloatingTextPrefab;
    public float maxHealth = 1f;
    private float currentHealth = 0f;
    public float speed = 1f;
    public float dmg = 2f;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;

        SetCountText();

        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 retning = transform.position;
        retning.Normalize();
        retning *= -1;
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
            sr.color = new Color(0.5f, 0.5f, 0.5f);

            if (FloatingTextPrefab)
            {
                ShowFloatingText();
            }

            if (currentHealth <= 0f)
            {
                CanvasController.Instance.countText += 1;
                SetCountText();
                Destroy(gameObject);
            }
        }

        if (collision.transform.tag == "Player")
        {
            Destroy(gameObject);
        }


    }

    void ShowFloatingText()
    {
        GameObject go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity) as GameObject;
        go.GetComponent<TextMesh>().text = "+" + dmg.ToString();
    }

    void SetCountText()
    {
        CanvasController.Instance.count.text = "Count: " + CanvasController.Instance.countText.ToString();
    }

}
