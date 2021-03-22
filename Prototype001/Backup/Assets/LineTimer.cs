using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTimer : MonoBehaviour {

    public float lifetime;
    public LineRenderer lr;

    // Use this for initialization
    void Start() {
        Destroy(gameObject, lifetime);
        Invoke("SetColor", lifetime / 2);
    }
    // Update is called once per frame
    void SetColor () {
        lr.startColor = new Color(0.5f, 0.5f, 0.5f);
        lr.endColor = lr.startColor;
	}


    
}
