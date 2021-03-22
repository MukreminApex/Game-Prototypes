using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_LvlComplete : MonoBehaviour {

    public void ClickedNextLevel()
    {
        GameManager.Instance.LoadNextLvl();
        PanelController.Instance.LvlComplete.SetActive(false);
        // PanelController.Instance.Score.SetActive(true);
    }
    public void ClickedRestart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PanelController.Instance.LvlComplete.SetActive(false);
        PanelController.Instance.GameOver.SetActive(false);
        PanelController.Instance.Score.SetActive(true);
    }
    public void ClickedMainMenu()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

        SceneManager.LoadScene("Menu");

        PanelController.Instance.LvlComplete.SetActive(false);
        PanelController.Instance.MainMenu.SetActive(true);
        PanelController.Instance.GameOver.SetActive(false);
        PanelController.Instance.Score.SetActive(false);
    }
}
