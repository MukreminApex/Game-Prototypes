using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTimer : MonoBehaviour {

    public float lifetime;
    public LineRenderer lr;
    private PlayerController _player;


    // Use this for initialization
    void Start() {


        Invoke("DestroyLine", lifetime);
        Invoke("SetColor", lifetime / 2);

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void SetColor () {
        lr.startColor = new Color(145, 145, 145);
        lr.endColor = lr.startColor;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "HpFriend")
        {
            _player.currentHealth += 5;
            _player.HealthBar.value = _player.currentHealth;

            _player.HealthBar.GetComponent<Animator>().SetTrigger("HpBar");
        }
    }

    void DestroyLine()
    {
        line.lineAmount -= 1;
        Destroy(gameObject);
    }
}
