using UnityEngine;
using UnityEngine.UI;

public class Spells : MonoBehaviour
{
    [SerializeField]
    private Sprite fireballIcon;

    public enum Spell
    {
        NOSPELL,
        Fireball,
        Teleport
    }

    public Spell currentSpell;

    void Update()
    {
        switch(currentSpell)
        {
            case Spell.NOSPELL:
                break;

            case Spell.Fireball:
                gameObject.GetComponentInParent<ActionBar>().allAbilityButtons[3].GetComponent<Image>().sprite = fireballIcon;
                break;

            case Spell.Teleport:
                break;
        }
    }
}
