using UnityEngine;

public class Teleport : Spell
{
    void Start()
    {
        spellCooldown = 1.0f;
    }

    void Update()
    {
        spellCooldown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(1) && spellCooldown <= 0) //Bug when running and teleport, running can take prio 
        {  
            this.GetComponent<ClickToMove>().playerAnimations.SetBool("isTeleporting", true);
        }
    }

    void setPosition()
    {
        this.GetComponent<ClickToMove>().mouseClickedPosition();
        this.GetComponent<ClickToMove>().setRotation();
        transform.position = this.GetComponent<ClickToMove>().newPlayerPosition;
        this.GetComponent<ClickToMove>().playerAnimations.SetBool("isTeleporting", false);
        spellCooldown = 1.0f;
    }
}
