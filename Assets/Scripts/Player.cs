using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool AbleToShoot = true;

    public float throwForce = 40f;
    public GameObject Grenade;

    public AudioSource middle;
    public AudioSource shoot;
    public AudioSource mine;

    public float ReloadTime;

    public GameObject Emitter;
    public GameObject Bullet;
    public GameObject Bullet2;

    public bool Reloaded2;
    public bool Reloaded;
    public bool Grenaded = true;

    public float BulletSpeed;
    public float BulletSpeed2;

    void Start()
    {
        Reloaded = true;
        Reloaded2 = true;
    }
    void Update () {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f));

        if (Input.GetButton("Fire1") && AbleToShoot == true)
        {
            if (Reloaded == true)
            {
                shoot.Play();
                GetComponent<CameraShaker>().shouldShake = true;
                GameObject TempoBullet;
                TempoBullet = Instantiate(Bullet, Emitter.transform.position, Emitter.transform.rotation) as GameObject;
                TempoBullet.transform.Rotate(Vector3.left * 0);
                Rigidbody TempoRigidBody;
                TempoRigidBody = TempoBullet.GetComponent<Rigidbody>();
                TempoRigidBody.AddForce(transform.forward * BulletSpeed);
                Destroy(TempoBullet, 1.0f);
                StartCoroutine(Reload());
            }

        }

        else if (Input.GetButton("Fire2") && AbleToShoot == true)
        {
            if (Reloaded2 == true)
            {
                middle.Play();
                GetComponent<CameraShaker>().shouldShake = true;
                GameObject TempoBullet2;
                TempoBullet2 = Instantiate(Bullet2, Emitter.transform.position, Emitter.transform.rotation) as GameObject;
                TempoBullet2.transform.Rotate(Vector3.left * 0);
                Rigidbody TempoRigidBody;
                TempoRigidBody = TempoBullet2.GetComponent<Rigidbody>();
                TempoRigidBody.AddForce(transform.forward * BulletSpeed2);
                Destroy(TempoBullet2, 1.0f);
                StartCoroutine(Reload2());
            }
        }

        else if (Input.GetButtonDown("Fire3") && Grenaded == true && AbleToShoot == true)
        {
            mine.Play();
            GetComponent<CameraShaker>().shouldShake = true;
            ThrowGrenade();
            StartCoroutine(GrenadeReload());
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(Grenade, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

    public IEnumerator Reload()
    {
        Reloaded = false;
        yield return new WaitForSeconds(ReloadTime);
        Reloaded = true;
    }

    public IEnumerator Reload2()
    {
        Reloaded2 = false;
        yield return new WaitForSeconds(ReloadTime / 5);
        Reloaded2 = true;
    }

    public IEnumerator GrenadeReload()
    {
        Grenaded = false;
        yield return new WaitForSeconds(ReloadTime * 30);
        Grenaded = true;
    }
}
