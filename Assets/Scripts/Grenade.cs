using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    public float delay = 3f;
    public float radius = 5f;
    public float force = 2200f;
    public AudioSource explode;

    bool hasExploded = false;

    public GameObject explosionEffect;

    float countdown;

	void Start () {
        countdown = delay;
	}
	
	void Update () {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
	}

    void Explode()
    {
        GameObject.Find("Main Camera").GetComponent<CameraShaker>().shouldShake = true;
        explode.Play();
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //Destroy(nearbyObject);
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        transform.Translate(Vector3.left * 100);
        Destroy(gameObject, 3f);
    }
}
