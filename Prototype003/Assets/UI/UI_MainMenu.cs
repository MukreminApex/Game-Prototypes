﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour {

    public void ClickedPlay()
    {
        // Change to load latest scene 
        SceneManager.LoadScene("MainScene");
        PanelController.Instance.MainMenu.SetActive(false);
        PanelController.Instance.Score.SetActive(true);
    }
    public void ClickedSelect()
    {
        PanelController.Instance.LvlSelect.SetActive(true);
        PanelController.Instance.MainMenu.SetActive(false);
    }
}
