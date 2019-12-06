using UnityEngine;
using UnityEngine.UI;

public class Spells : MonoBehaviour
{
    [SerializeField]
    private Image[] actionBarIcon;
    [SerializeField]
    private Image[] actionBarIconInSkillsandStatsUI;

    public Spell[] mySpells;

    void Start()
    {
        actionBarIcon[0].sprite = mySpells[0].spellIcon;
        actionBarIcon[1].sprite = mySpells[1].spellIcon;
        actionBarIcon[2].sprite = mySpells[2].spellIcon;

        actionBarIconInSkillsandStatsUI[0].sprite = actionBarIcon[0].sprite;
        actionBarIconInSkillsandStatsUI[1].sprite = actionBarIcon[1].sprite;
        actionBarIconInSkillsandStatsUI[2].sprite = actionBarIcon[2].sprite;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CastSpell(mySpells[0].spellId);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CastSpell(mySpells[1].spellId);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CastSpell(mySpells[2].spellId);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            var temp = mySpells[0];
            mySpells[0] = mySpells[1];
            mySpells[1] = temp;

            actionBarIcon[0].sprite = mySpells[0].spellIcon;
            actionBarIcon[1].sprite = mySpells[1].spellIcon;
            actionBarIcon[2].sprite = mySpells[2].spellIcon;
        }
    }

    void CastSpell(int id)
    {
        switch(id) //Actaully Works !!!!!!!!!! POG
        {
            case 0:
                Debug.Log("Used Fireball");
                this.GetComponent<ClickToMove>().playerAnimations.SetBool("castFireball", true);
                break;
            case 1:
                Debug.Log("Used Frostbolt");
                break;
            case 2:
                Debug.Log("Used Lightingbolt");
                break;
        }
    }
}
