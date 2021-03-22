using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    static int currentlvl = 0;
    public Camera mainCamera;

    public List<string> allScenes = new List<string>();

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

    public void LoadLvl(int lvl)
    {
        currentlvl = lvl;
        SceneManager.LoadScene(allScenes[currentlvl]);
    }
}
