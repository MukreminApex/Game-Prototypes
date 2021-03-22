using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarpEffect : MonoBehaviour {

    public Slider slider;
    public ParticleSystem ParticleEffect;


    //private float min = 10; // 15
    //private float quar = 25; // 30
    //private float mid = 50; // 45
    //private float tyv = 75; // 60
    //private float max = 150; // 100!!!



	// Use this for initialization
	void Start () {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var main = ps.main;

        var em = ps.emission;
        em.enabled = true;

        em.rateOverTime = 0;
    }

    // Update is called once per frame
    void Update () {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        var em = ps.emission;

        if (slider.value >= 15 && slider.value < 30)
        {
            em.rateOverTime = 5;
        }
        if (slider.value >= 30 && slider.value < 45)
        {
            em.rateOverTime = 15;
        }
        if (slider.value >= 45 && slider.value < 60)
        {
            em.rateOverTime = 25;
        }
        if (slider.value >= 60 && slider.value < 100)
        {
            em.rateOverTime = 50;
        }
        if (slider.value >= 100)
        {
            em.rateOverTime = 250;
        }
        if (slider.value <= 0 && slider.value < 15)
        {
            em.rateOverTime = 0;
        }
    }
}
