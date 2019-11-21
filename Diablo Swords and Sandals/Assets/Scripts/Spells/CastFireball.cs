using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireball : Spell
{
    [SerializeField]
    GameObject Fireball;

    [SerializeField]
    Transform FireballLocation;

    public LayerMask enemyLayer;

    void Start()
    {
        spellCooldown = 0.1f;
    }

    void Update()
    {
        spellCooldown -= Time.deltaTime;

        if(Input.GetKey(KeyCode.Alpha1) && spellCooldown < 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000, enemyLayer))
            {
                this.GetComponent<ClickToMove>().playerAnimations.SetBool("castFireball", true);
            }  
        }
    }

    void castFireball()
    {
        Instantiate(Fireball, FireballLocation.position, FireballLocation.rotation);
        this.GetComponent<ClickToMove>().playerAnimations.SetBool("castFireball", false);
        spellCooldown = 0.1f;
    }
}
