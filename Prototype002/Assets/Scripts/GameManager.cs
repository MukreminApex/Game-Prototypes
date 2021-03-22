using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Animator GameOverAnimator;
    public PlatformManager _platformMan;
    public Animator HiScoreEnd;
    private GameObject _player;

	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 60;
        _player = GameObject.FindGameObjectWithTag("Player");
	}
	
    public void GameOver()
    {
        GameOverAnimator.SetBool("IsGameOver", true);
        _player.GetComponent<myPlayerController>().enabled = false;
        // _platformMan.GetComponent<PlatformManager>().enabled = false;
    }

    public void HiEnd()
    {
        HiScoreEnd.SetBool("IsEnd", true);
    }
	// Update is called once per frame
	void Update ()
    {
		
	}
}
