using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCollision : MonoBehaviour {

    void OnCollisionEnter(Collision enemy)
    {
       if (enemy.gameObject.tag == "Enemy" || enemy.transform.tag == "Enemy2" || enemy.transform.tag == "Enemy3")
       {
            Debug.Log("Powerup destroyed");
            Destroy(gameObject);
       } 
    }
}
