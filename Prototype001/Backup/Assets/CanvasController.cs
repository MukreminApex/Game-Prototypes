using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {
    public Text count;
    public int countText;


    private static CanvasController _instance;

    public static CanvasController Instance
    {
        get { return _instance; }
    }

	// Use this for initialization
	void Awake () {
		if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else 
        {
            _instance = this;
        }
            
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
