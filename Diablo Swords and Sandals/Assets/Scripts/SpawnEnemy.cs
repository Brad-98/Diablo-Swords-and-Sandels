using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject ZombiePrefab;

    private float spawnTimer;
    private int counter = 0;

    void Start()
    {
        spawnTimer = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0 && counter < 5)
        {
            Instantiate(ZombiePrefab, transform.position, transform.rotation);
            spawnTimer = Random.Range(1, 4);
            counter++;
        }
    }
}
