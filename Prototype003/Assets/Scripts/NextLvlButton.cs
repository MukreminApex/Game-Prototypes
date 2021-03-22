using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextLvlButton : MonoBehaviour {

    public Button _nextLvlButton;
    private string currentSceneName;

    // Use this for initialization
    void Start()
    {
      // _nextLvlButton.onClick.AddListener(OnMouseDown);
      //
      // currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void OnMouseDown()
    {
        NextLvl();
    }

    private void NextLvl()
    {

    }

}
