using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMenu : MonoBehaviour {

    public bool Reloaded;

    public AudioSource shoot;

    private Transform target;

    public GameObject Emitter;
    public GameObject Bullet;

    public float BulletSpeed;

    // Update is called once per frame
    void Update () {

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            return;
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
            Vector3 xpos = new Vector3(target.position.x, 1, 1f);
            transform.position = Vector3.Lerp(transform.position, xpos, 0.1f);
        }
        if (Reloaded == true)
        {
            shoot.Play();
            GameObject TempoBullet;
            TempoBullet = Instantiate(Bullet, Emitter.transform.position, Emitter.transform.rotation) as GameObject;
            TempoBullet.transform.Rotate(Vector3.left * 0);
            Rigidbody TempoRigidBody;
            TempoRigidBody = TempoBullet.GetComponent<Rigidbody>();
            TempoRigidBody.AddForce(transform.forward * BulletSpeed);
            Destroy(TempoBullet, 1.0f);
            StartCoroutine(Reload());
            GetComponent<CameraShaker>().shouldShake = true;
        }
    }

    public IEnumerator Reload()
    {
        Reloaded = false;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
        Reloaded = true;
    }
}
