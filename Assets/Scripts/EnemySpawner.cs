using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public float Rspawn1;
    public float Rspawn2;
    public bool Spawn;
    private float SpawnTime;
    public GameObject enemy;
    float randX;

    private Vector3 SpawnRange;

    void Start()
    {
        Spawn = true;
    }

    void Update () {
        SpawnTime = Random.Range(Rspawn1, Rspawn2);
        randX = Random.Range(-6, 6);
        if (Spawn == true)
        {
            StartCoroutine(Spawner());
            Spawn = false;
        }
    }

    public IEnumerator Spawner()
    {
        yield return new WaitForSeconds(SpawnTime);
        SpawnRange = new Vector3(randX, 0f, 7f);
        Instantiate(enemy, SpawnRange, Quaternion.identity);

        Spawn = true;
    }
}
