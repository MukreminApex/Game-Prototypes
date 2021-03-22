using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour {

    public Button _button;
    private line line;

    // Use this for initialization


    void Start () {

        
        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(ClickPlayAgain);
        _button.interactable = false;
    }

    public void ClickPlayAgain()
    {
        line.lineAmount = 0;
        SceneManager.LoadScene("MainScene");
        // Time.time = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
