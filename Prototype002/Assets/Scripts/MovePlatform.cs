using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {

    #region Instance Fields

    Rigidbody rb;

    private Vector2 randXPos = new Vector2(-2.5f, 2.5f) ; // between -2.5 & 2.5
    private Vector2 randZPos = new Vector2(-5, 5); // a certain distance from the player, to spawn on platform
    private Vector2 randYPos = new Vector2(0.1f, 0.5f); // spawn in air
    public GameObject coin;


    #endregion

    #region MonoBehaviour

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void SpawnCoins()
    {
        for (int i = 0; i < 7; i++)
        {
            var g = Instantiate(coin, SpawnPosition(), Quaternion.identity, transform);
            g.transform.localPosition = SpawnPosition();
        }
    }

    private Vector3 SpawnPosition()
    {
        return new Vector3(Random.Range(randXPos.x, randXPos.y),
            Random.Range(randYPos.x, randYPos.y),
            Random.Range(randZPos.x, randZPos.y));
    }
    #endregion
}
