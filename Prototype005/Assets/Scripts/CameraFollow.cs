using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Vector3 offset;         //Private variable to store the offset distance between the player and camera
    private int isActive = 1;



    private void Update()
    {
        //if (PanelController.Instance.GameOver.SetActive(true))
        //{
        //    offset(0, 10, -10);
        //}
    }
    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (Player.Instance != null)
        {
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = Player.Instance.transform.position + offset;
        }
    }
}
