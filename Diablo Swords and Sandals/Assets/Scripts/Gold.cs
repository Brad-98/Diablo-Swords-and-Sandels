using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private Transform playerGoldCollectLocation;
    public float MinModifier = 7;
    public float MaxModifier = 11;

    Vector3 _Velocity = Vector3.zero;

    void Start()
    {
        playerGoldCollectLocation = GameObject.Find("Player/GoldCollectLocation").transform; 
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, playerGoldCollectLocation.position, ref _Velocity, Time.deltaTime * Random.Range(MinModifier, MaxModifier));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameStats.instance.playerGold += 1;
            Destroy(gameObject);
        }
    }
}
