using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastArcaneMissles : MonoBehaviour
{
    [SerializeField]
    GameObject ArcaneMisslePrefab;

    [SerializeField]
    Transform ArcaneMisslelLocation1;
    [SerializeField]
    Transform ArcaneMisslelLocation2;
    [SerializeField]
    Transform ArcaneMisslelLocation3;

    public LayerMask enemyLayer;
    public float spellCooldown;

    public static bool active = false;

    void Start()
    {
        spellCooldown = 1.0f;
    }

    void Update()
    {
        spellCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha3) && spellCooldown < 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000, enemyLayer))
            {
                ArcaneMissle.zombieTarget = hit.transform;
                this.GetComponent<ClickToMove>().playerAnimations.SetBool("castArcaneMissle", true);
                ClickToMove.isAttacking = true;
            }
        }
    }

    void castArcaneMissle()
    {
        Instantiate(ArcaneMisslePrefab, ArcaneMisslelLocation1.position, ArcaneMisslelLocation1.rotation);
        Instantiate(ArcaneMisslePrefab, ArcaneMisslelLocation2.position, ArcaneMisslelLocation2.rotation);
        Instantiate(ArcaneMisslePrefab, ArcaneMisslelLocation3.position, ArcaneMisslelLocation3.rotation);
    }

    void launchMissle()
    {
        active = true;
    }

    void StopAnimation()
    {
        this.GetComponent<ClickToMove>().playerAnimations.SetBool("castArcaneMissle", false);
        ClickToMove.isAttacking = false;
        spellCooldown = 1.0f;
        active = false;
    }
}
