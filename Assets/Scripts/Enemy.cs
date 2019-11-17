using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private float MoveSpeed = 5.5f;

    void Update ()
    {
        gameObject.transform.Translate(Vector3.back * Time.deltaTime * MoveSpeed);
    }
}
