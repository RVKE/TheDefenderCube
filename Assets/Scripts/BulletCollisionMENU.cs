using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionMENU : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            transform.Translate(Vector3.left * 100);
            Destroy(gameObject, 3f);
        }
    }
}
