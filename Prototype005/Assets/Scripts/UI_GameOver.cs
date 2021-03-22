using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GameOver : MonoBehaviour {

    public void ClickedRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PanelController.Instance.MainMenu.SetActive(false);
        PanelController.Instance.GameOver.SetActive(false);
        PanelController.Instance.UI.SetActive(true);
    }
    public void ClickedMainMenu()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

        SceneManager.LoadScene("Menu");

        PanelController.Instance.MainMenu.SetActive(true);
        PanelController.Instance.GameOver.SetActive(false);
        PanelController.Instance.UI.SetActive(false);
    }
}
