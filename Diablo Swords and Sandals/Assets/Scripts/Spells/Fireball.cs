using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private float fireballSpeed = 15;
    public static Transform zombieTarget;

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
