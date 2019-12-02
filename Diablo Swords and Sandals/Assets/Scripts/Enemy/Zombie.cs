using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private Transform playerLocation;

    [SerializeField]
    private float speed = 1.0f;

    void Start()
    {
        playerLocation = GameObject.Find("Player/enemyTarget").transform;
    }

    void Update()
    {
        transform.LookAt(playerLocation.position);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Fireball") 
        {
            Destroy(gameObject);
            //-enemyHealth
        }
    }
}
