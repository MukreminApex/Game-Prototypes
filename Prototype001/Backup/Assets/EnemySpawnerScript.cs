using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

    public GameObject bigEnemy;
    public GameObject enemy;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    public float spawnRateBig = 4f;
    float nextSpawn = 0.0f;
    float nextSpawn2 = 0.0f;
    public float spawnRadius = 15;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn)
        {
            var angle = Random.Range(0, 360);
            var x = Mathf.Cos(angle * Mathf.Deg2Rad);
            var y = Mathf.Sin(angle * Mathf.Deg2Rad);

            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector2(x, y) * spawnRadius;
            var newEnemy = GameObject.Instantiate(enemy);
            newEnemy.transform.position = whereToSpawn;
        }
        if (Time.time > nextSpawn2)
        {
            var angle = Random.Range(0, 360);
            var x = Mathf.Cos(angle * Mathf.Deg2Rad);
            var y = Mathf.Sin(angle * Mathf.Deg2Rad);

            nextSpawn2 = Time.time + spawnRateBig;
            whereToSpawn = new Vector2(x, y) * spawnRadius;
            var big = GameObject.Instantiate(bigEnemy);
            big.transform.position = whereToSpawn;
        }
    }
}
