using UnityEngine;

public class Fireball : Spell
{
    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private float fireballSpeed = 15;
    private Transform zombieTarget;

    void Start()
    {
        zombieTarget = GameObject.Find("Zombie/zombieTarget").transform;
    }

    void Update()
    {
        if (zombieTarget)
        {
            transform.LookAt(zombieTarget.position);
            transform.position += transform.forward * fireballSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
