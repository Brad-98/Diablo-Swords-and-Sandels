using UnityEngine;

public class ArcaneMissle : MonoBehaviour
{
    [SerializeField]
    private float arcaneMissleSpeed = 15;
    public static Transform zombieTarget;

    void Update()
    {
        if (zombieTarget && CastArcaneMissles.active == true)
        {
            transform.LookAt(zombieTarget.position);
            transform.position += transform.forward * arcaneMissleSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
