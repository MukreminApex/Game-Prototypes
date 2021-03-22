using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour {

    private Button _button;

	// Use this for initialization
	void Start () {
        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(ClickPlayAgain);
	}
	
    public void ClickPlayAgain()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
