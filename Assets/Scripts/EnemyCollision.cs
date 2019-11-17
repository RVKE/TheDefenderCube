using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCollision : MonoBehaviour {

    private GameObject player;
    public GameObject secondPlayer;
    public GameObject deathEffect;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(secondPlayer, new Vector3(0, 0, -10), Quaternion.identity);
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(player);
            Destroy(gameObject);
        }
    }
}
