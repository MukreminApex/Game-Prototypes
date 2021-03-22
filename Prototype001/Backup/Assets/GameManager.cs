using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Animator GameOverAnimator;
    public line _line;
    public EnemySpawnerScript _espawn;

    private GameObject _player;


    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void GameOver()
    {
        GameOverAnimator.SetBool("IsGameOver", true);
        _player.GetComponent<PlayerController>().enabled = false;
        _line.enabled = false;
        _espawn.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
