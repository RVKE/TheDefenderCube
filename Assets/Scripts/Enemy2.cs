﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float lives;
    private float Hits;
    private Transform target;
    public AudioSource shootenemy;
    public AudioSource dead;
    public AudioSource hit;
    private float ShootTime;
    public float BulletSpeed;
    public GameObject Emitter;
    public GameObject Bullet;
    public bool CanShoot = true;
    public float MoveSpeed;

    void Start()
    {
        Hits = 0;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        ShootTime = Random.Range(0.4f, 2f);
        if (CanShoot == true)
        {
            StartCoroutine(Shoot());
            CanShoot = false;
        }
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
        }
    }
    public IEnumerator Shoot()
    {
        shootenemy.Play();
        GameObject TempoBullet;
        TempoBullet = Instantiate(Bullet, Emitter.transform.position, Emitter.transform.rotation) as GameObject;
        TempoBullet.transform.Rotate(Vector3.left * 0);
        Rigidbody TempoRigidBody;
        TempoRigidBody = TempoBullet.GetComponent<Rigidbody>();
        TempoRigidBody.AddForce(transform.forward * BulletSpeed * -1);
        Destroy(TempoBullet, 4.0f);
        yield return new WaitForSeconds(ShootTime);
        CanShoot = true;
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
                GameObject.Find("main").GetComponent<Main>().score += 8.0f;
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
                GameObject.Find("main").GetComponent<Main>().score += 8.0f;
                GameObject.Find("main").GetComponent<Main>().kills += 1.0f;
                dead.Play();
                transform.Translate(Vector3.left * 100);
                Destroy(gameObject, 0.7f);
            }
        }
    }

}
