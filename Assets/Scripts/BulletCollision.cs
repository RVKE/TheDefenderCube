using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

    public AudioSource hit;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            GameObject.Find("main").GetComponent<Main>().kills += 1.0f;
            GameObject.Find("main").GetComponent<Main>().score += 1.0f;
            hit.Play();
            Destroy(col.gameObject);
            transform.Translate(Vector3.left * 100);
            Destroy(gameObject, 3f);
        }
    }
}
