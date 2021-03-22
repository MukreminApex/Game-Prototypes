using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;

    private float gameStartTime = 10f;
    Vector2 whereToSpawn;
    public float spawnRate;

    float nextSpawn;

    public static int enemyCount = 0;
    private int maxEnemyCount = 1;
    
	// Use this for initialization
	void Start () {
        gameStartTime = Time.time;
        nextSpawn = spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - gameStartTime > nextSpawn && enemyCount < maxEnemyCount && Player.Instance.isGrounded == true)
        {
            var x = Player.Instance.spawner.transform.position.x;
            var y = Player.Instance.spawner.transform.position.y;

            nextSpawn = (Time.time - gameStartTime) + spawnRate;
            whereToSpawn = new Vector2(x, y);
            var newEnemy = GameObject.Instantiate(enemy);
            newEnemy.transform.position = whereToSpawn;
            enemyCount++;
        }
    }
}
