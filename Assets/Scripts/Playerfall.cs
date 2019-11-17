using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerfall : MonoBehaviour {
    public AudioSource klik;
    public GameObject player;
    public GameObject wait;
    public GameObject secondPlayer;

    void Start()
    {
        wait.SetActive(false);
    }
    void Update () {
        if (transform.position.y < -1f)
        {
            klik.Play();
            Instantiate(secondPlayer, new Vector3(0, 0, -10), Quaternion.identity);
            Destroy(player);
            wait.SetActive(true);
        }
    }
}
