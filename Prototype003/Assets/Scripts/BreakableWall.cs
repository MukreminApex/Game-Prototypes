using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour {

    public GameObject BreakEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameObject tmpParticles = (GameObject)Instantiate(BreakEffect, transform.position, Quaternion.identity);
            Destroy(tmpParticles, 3f);
            Destroy(gameObject);
        }
    }
}
