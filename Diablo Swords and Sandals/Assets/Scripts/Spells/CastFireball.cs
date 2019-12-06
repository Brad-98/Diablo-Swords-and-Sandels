using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireball : MonoBehaviour
{
    [SerializeField]
    GameObject FireballPrefab;

    [SerializeField]
    Transform FireballLocation;

    public LayerMask enemyLayer;
    public float spellCooldown;

    void Start()
    {
        spellCooldown = 0.1f;
    }

    void Update()
    {
        spellCooldown -= Time.deltaTime;

        if(Input.GetMouseButton(0) && spellCooldown < 0) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000, enemyLayer))
            {
                Fireball.zombieTarget = hit.transform;
                this.GetComponent<ClickToMove>().playerAnimations.SetBool("castFireball", true);
                ClickToMove.isAttacking = true;
            }  
        }
    }

    void castFireball()
    {
        Instantiate(FireballPrefab, FireballLocation.position, FireballLocation.rotation);
        this.GetComponent<ClickToMove>().playerAnimations.SetBool("castFireball", false);
        ClickToMove.isAttacking = false;
        spellCooldown = 0.1f;
        
    }
}
