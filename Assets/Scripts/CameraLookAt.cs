using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 1.0f;
    private float pitch = 1.0f;

    //public Transform target;

	void Update () {
        //yaw += speedH * Input.GetKey("t");
        //pitch += speedV * Input.GetButton("mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        //transform.LookAt(target, Vector3.forward);
    }
}
