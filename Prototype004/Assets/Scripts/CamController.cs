using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    public void StartCameraShake(float power, float duration)
    {
        StartCoroutine(CameraShake(power, duration));
    }

    IEnumerator CameraShake(float power, float duration)
    {
        float t = duration;
        while (t > 0)
        {
            float rX = Random.Range(-1, 1) * power;
            float rY = Random.Range(-1, 1) * power;
            power -= Time.unscaledDeltaTime * .1f;
            t -= Time.unscaledDeltaTime;
            transform.position = new Vector3(rX, rY, -10);
            yield return null;
        }
        transform.position = new Vector3(0, 0, -10);
    }

}
