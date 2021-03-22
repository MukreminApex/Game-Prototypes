using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public CamController camController;

    public float drawback;
    public float maxPower;

    public static int playerPoints;
    static int currentLvl = 0;
    public static int balls = 0;

    public List<string> allScenes = new List<string>();

    public Camera mainCamera;

    // Use this for initialization
    void Start () {
        Application.targetFrameRate = 60;

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void LoadNextLvl()
    {
        currentLvl++;

        SceneManager.LoadScene(allScenes[currentLvl]);
    }

    public void LoadLvl(int lvl)
    {
        currentLvl = lvl;
        SceneManager.LoadScene(allScenes[currentLvl]);
    }
}
