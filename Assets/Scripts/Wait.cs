using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour {

    public AudioSource klik;

    public GameObject wait;
    void Start () {
        wait.SetActive(false);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Enemy2" || col.gameObject.tag == "Enemy3" || col.gameObject.tag == "EnemyBullet")
        {
            klik.Play();
            wait.SetActive(true);
        }
    }
}
