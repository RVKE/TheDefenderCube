using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    private bool Spawn = true;
    public float spawnTimeMin;
    public float spawnTimeMax;
    public GameObject powerup;
    float randX;
    public float Y;
    float randZ;

    private Vector3 SpawnRange;

    void Update()
    {
        randX = Random.Range(-4, 4);
        randZ = Random.Range(-4, 4);
        if (Spawn == true)
        {
            StartCoroutine(Spawner());
        }
    }

    public IEnumerator Spawner()
    {
        Spawn = false;
        yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        SpawnRange = new Vector3(randX, Y, randZ);
        Instantiate(powerup, SpawnRange, Quaternion.identity);
        Spawn = true;
    }
}
