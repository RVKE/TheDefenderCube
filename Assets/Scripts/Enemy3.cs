using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public float lives;
    private float Hits;
    public AudioSource hit;
    public AudioSource dead;

    private Transform target;
    private float MoveSpeed = 5.75f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            hit.Play();
            Hits += 1;
            Destroy(col.gameObject);
            if (Hits > lives)
            {
                GameObject.Find("main").GetComponent<Main>().score += 3.0f;
                GameObject.Find("main").GetComponent<Main>().kills += 1.0f;
                dead.Play();
                transform.Translate(Vector3.left * 100);
                Destroy(gameObject, 0.7f);
            }
        }
        if (col.gameObject.tag == "Bullet2")
        {
            hit.Play();
            Hits += 0.1f;
            Destroy(col.gameObject);
            if (Hits > lives)
            {
                GameObject.Find("main").GetComponent<Main>().score += 3.0f;
                GameObject.Find("main").GetComponent<Main>().kills += 1.0f;
                dead.Play();
                transform.Translate(Vector3.left * 100);
                Destroy(gameObject, 0.7f);
            }
        }
    }
}
