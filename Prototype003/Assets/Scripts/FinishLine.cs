using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour {

    public GameObject player;
    private GameObject _player;
    private GameObject _flag;
    private GameObject lvlCompletePanel;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PanelController.Instance.LvlComplete.SetActive(true);
        }
    }
}
