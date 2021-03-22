using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public GameObject PickUpEffect;

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
            GameObject tmpParticles = (GameObject)Instantiate(PickUpEffect, transform.position, Quaternion.identity);
            Destroy(tmpParticles, 3f);
        }
    }
}
