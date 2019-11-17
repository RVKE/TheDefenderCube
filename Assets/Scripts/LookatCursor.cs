using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatCursor : MonoBehaviour {

    public GameObject pointer;
    public Camera cam;
    private Vector3 lookpoint;

    void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
    }
	
	void Update () {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayhit;

        if (Physics.Raycast(ray, out rayhit))
        {
            lookpoint = new Vector3(rayhit.point.x, transform.position.y, rayhit.point.z);
            transform.LookAt(lookpoint);
        }
}
}
