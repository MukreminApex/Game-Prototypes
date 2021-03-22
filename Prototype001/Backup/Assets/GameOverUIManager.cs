using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour {

    private Button _button;

	// Use this for initialization
	void Start () {
        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(ClickPlayAgain);

	}

    public void ClickPlayAgain()
    {
        SceneManager.LoadScene("MainScene");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
