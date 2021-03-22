using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu : MonoBehaviour {

    public void ClickedPlay()
    {
        // Change to load latest scene 
        SceneManager.LoadScene("MainScene");
        PanelController.Instance.MainMenu.SetActive(false);
        PanelController.Instance.UI.SetActive(true);
    }
}
