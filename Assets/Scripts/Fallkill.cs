using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallkill : MonoBehaviour {

    public AudioSource hit;
    public bool fallkilled = false;
    void Update()
    {
        if (transform.position.y < -3f)
        {
            if (fallkilled.Equals (true))
            {
                hit.Play();
                GameObject.Find("main").GetComponent<Main>().kills += 1.0f;
                GameObject.Find("main").GetComponent<Main>().score += 3.0f;
                fallkilled = false;
                Destroy(gameObject, 1f);
            }
        }
    }
}
