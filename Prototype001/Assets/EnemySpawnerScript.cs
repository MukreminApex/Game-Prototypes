using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

    public GameObject bigEnemy;
    public GameObject enemy;
    public GameObject smallEnemy;
    public GameObject hpFriend;
    public GameObject _player;

    public float gameStartTime;

    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    public float spawnRateBig = 20.25f;
    public float spawnRateSmall = 31.5f;
    public float spawnRateHp = 30f;

    float nextSpawn = 0.0f;
    float nextSpawn2;
    float nextSpawn3;
    float nextSpawn4;

    public float spawnRadius = 15;
    public float increaseDifRate = 10f;

    private float diftimer;
    float lastCollisionTime;
    bool isDead = false;
    private float revDirDur = 0.4f;
    private bool CircleCollider2D = true;
    private bool Rigidbody2D = true;

    // Use this for initialization
    void Start () {
        gameStartTime = Time.time;
        nextSpawn2 = spawnRateBig;
        nextSpawn3 = spawnRateSmall;
        nextSpawn4 = spawnRateHp;

        diftimer = increaseDifRate;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - gameStartTime > nextSpawn)
        {
            float leftangle = 180;
            float rightangle = 360;

            var angle = Random.value > 0.5f ? 
                Random.Range(leftangle -45, leftangle + 45) : 
                Random.Range(rightangle -45, rightangle + 45);

            var x = Mathf.Cos(angle * Mathf.Deg2Rad);
            var y = Mathf.Sin(angle * Mathf.Deg2Rad);

            nextSpawn = (Time.time - gameStartTime) + spawnRate;
            whereToSpawn = new Vector2(x, y) * spawnRadius;
            var newEnemy = GameObject.Instantiate(enemy);
            newEnemy.transform.position = whereToSpawn;
        }
        if (Time.time - gameStartTime > nextSpawn2)
        {
            float leftangle = 180;
            float rightangle = 360;

            var angle = Random.value > 0.5f ?
                Random.Range(leftangle - 45, leftangle + 45) :
                Random.Range(rightangle - 45, rightangle + 45);

            var x = Mathf.Cos(angle * Mathf.Deg2Rad);
            var y = Mathf.Sin(angle * Mathf.Deg2Rad);

            nextSpawn2 = (Time.time - gameStartTime) + spawnRateBig;
            whereToSpawn = new Vector2(x, y) * spawnRadius;
            var big = GameObject.Instantiate(bigEnemy);
            big.transform.position = whereToSpawn;
        }

        if (Time.time - gameStartTime > nextSpawn3)
        {
            float leftangle = 180;
            float rightangle = 360;

            var angle = Random.value > 0.5f ?
                Random.Range(leftangle - 45, leftangle + 45) :
                Random.Range(rightangle - 45, rightangle + 45);


            var x = Mathf.Cos(angle * Mathf.Deg2Rad);
            var y = Mathf.Sin(angle * Mathf.Deg2Rad);

            nextSpawn3 = (Time.time - gameStartTime) + spawnRateSmall;
            whereToSpawn = new Vector2(x, y) * spawnRadius;
            var small = GameObject.Instantiate(smallEnemy);
            small.transform.position = whereToSpawn;
        }

        if (Time.time - gameStartTime > nextSpawn4)
        {
            float leftangle = 180;
            float rightangle = 360;

            var angle = Random.value > 0.5f ?
                Random.Range(leftangle - 45, leftangle + 45) :
                Random.Range(rightangle - 45, rightangle + 45);

            var x = Mathf.Cos(angle * Mathf.Deg2Rad);
            var y = Mathf.Sin(angle * Mathf.Deg2Rad);

            nextSpawn4 = (Time.time - gameStartTime) + spawnRateHp;
            whereToSpawn = new Vector2(x, y) * spawnRadius;
            var hp = GameObject.Instantiate(hpFriend);
            hp.transform.position = whereToSpawn;
        }

        if (Time.time - gameStartTime > diftimer)
        {
            IncDif();
            diftimer = (Time.time - gameStartTime) + increaseDifRate;
        }
    }

    void IncDif()
    {
        if (spawnRate > 0.8f)
        {
            spawnRate -= 0.15f;
        }

        if (spawnRateBig > 1.5f)
        {
            spawnRateBig -= 0.9375f;
        }
        if (spawnRateSmall > 2.6f)
        {
            spawnRateSmall -= 1.525f;
        }
        
    }
}
