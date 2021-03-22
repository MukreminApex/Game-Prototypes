using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_LvlSelect : MonoBehaviour {

    public void ClickedLvl1()
    {
        // Change to load latest scene 
        GameManager.Instance.LoadLvl(0);
        PanelController.Instance.LvlSelect.SetActive(false);
        PanelController.Instance.Score.SetActive(true);
    }
    public void ClickedLvl2()
    {
        // Change to load latest scene 
        GameManager.Instance.LoadLvl(1);
        PanelController.Instance.LvlSelect.SetActive(false);
        PanelController.Instance.Score.SetActive(true);
    }
    public void ClickedLvl3()
    {
        // Change to load latest scene 
        GameManager.Instance.LoadLvl(2);
        PanelController.Instance.LvlSelect.SetActive(false);
        PanelController.Instance.Score.SetActive(true);
    }
    public void ClickedLvl4()
    {
        // Change to load latest scene 
        GameManager.Instance.LoadLvl(3);
        PanelController.Instance.LvlSelect.SetActive(false);
        PanelController.Instance.Score.SetActive(true);
    }
    public void ClickedLvl5()
    {
        // Change to load latest scene 
        GameManager.Instance.LoadLvl(4);
        PanelController.Instance.LvlSelect.SetActive(false);
        PanelController.Instance.Score.SetActive(true);
    }
    public void ClickedLvl6()
    {
        // Change to load latest scene 
        GameManager.Instance.LoadLvl(5);
        PanelController.Instance.LvlSelect.SetActive(false);
        PanelController.Instance.Score.SetActive(true);
    }
    public void ClickedLvl7()
    {
        // Change to load latest scene 
        GameManager.Instance.LoadLvl(6);
        PanelController.Instance.LvlSelect.SetActive(false);
        PanelController.Instance.Score.SetActive(true);
    }
    public void ClickedLvl8()
    {
        // Change to load latest scene 
        GameManager.Instance.LoadLvl(7);
        PanelController.Instance.LvlSelect.SetActive(false);
        PanelController.Instance.Score.SetActive(true);
    }
    public void ClickedBack()
    {
        PanelController.Instance.LvlSelect.SetActive(false);
        PanelController.Instance.MainMenu.SetActive(true);
    }
}
