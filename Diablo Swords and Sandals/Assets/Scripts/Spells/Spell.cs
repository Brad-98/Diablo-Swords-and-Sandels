using UnityEngine;

[System.Serializable]
public class Spell
{
    public Sprite spellIcon;
    public string spellName;
    public string spellDescription;
    public int spellId;

    public Spell(Spell d)
    {
        spellIcon = d.spellIcon;
        spellName = d.spellName;
        spellDescription = d.spellDescription;
        spellId = d.spellId;
    }
}
