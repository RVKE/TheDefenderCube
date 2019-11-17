using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5: MonoBehaviour
{
    public float Stopzone;

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

    public float rotationDamping;

    void Start()
    {
        Hits = 0;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        LookAtPlayer();

        ShootTime = Random.Range(0.5f, 1f);
        if (CanShoot == true)
        {
            StartCoroutine(Shoot());
            CanShoot = false;
        }
        if (target != null) { 
            if (Vector3.Distance(transform.position, target.position) > Stopzone)
            {
                gameObject.transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
            }
        }
    }

    void LookAtPlayer()
    {
        if (target != null)
        {
            Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
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
        TempoRigidBody.AddForce(transform.forward * BulletSpeed);
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
                GameObject.Find("main").GetComponent<Main>().kills += 1.0f;
                GameObject.Find("main").GetComponent<Main>().score += 12.0f;
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
                GameObject.Find("main").GetComponent<Main>().kills += 1.0f;
                GameObject.Find("main").GetComponent<Main>().score += 12.0f;
                dead.Play();
                transform.Translate(Vector3.left * 100);
                Destroy(gameObject, 0.7f);
            }
        }
    }

}
