using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

    private static PanelController _instance;

    public static PanelController Instance { get { return _instance; } }


    public GameObject Canvas;

    public GameObject MainMenu;
    public GameObject LvlComplete;
    public GameObject GameOver;
    public GameObject LvlSelect;
    public GameObject Score;
    


	// Use this for initialization
	void Start () {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(Canvas);


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
