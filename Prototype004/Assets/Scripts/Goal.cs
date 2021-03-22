using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public BoxCollider2D triggerZone;
    public int pointsPerBall;

    private int amountInGoal = 0;

    public ParticleSystem enterEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GivePoints()
    {
        GameManager.playerPoints += pointsPerBall;
        // GameManager.playerPoints = pointsPerBall * // balls in goal checked via collisionenter
    }

    void RemovePoints()
    {
        GameManager.playerPoints -= pointsPerBall;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            GivePoints();
            collision.transform.GetComponent<SpriteRenderer>().color = Color.cyan;


            ParticleSystem tmpParticles = (ParticleSystem)Instantiate(enterEffect, transform.position, Quaternion.identity);
            Destroy(tmpParticles, 3f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            RemovePoints();
            collision.transform.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
