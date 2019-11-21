using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    private int howManyAbilitys = 5;
    public GameObject abilityButtonPrefab;
    public List<GameObject> allAbilityButtons = new List<GameObject>();

    void Start() //FIGURE OUT HOW TO SELECT AN ELEMENT IN THE LIST                
    {            //Maybe in the magic shop interface will choose the element. Still needs to work with the howManyAbilitys varible
        for (int i = 0; i < howManyAbilitys; i++)
        {
            GameObject newAbilityButtonObject = Instantiate(abilityButtonPrefab, transform);
            allAbilityButtons.Add(newAbilityButtonObject);
        }

        //Remove this with real keybindings
        allAbilityButtons[0].GetComponentInChildren<Text>().text = "1";
        allAbilityButtons[1].GetComponentInChildren<Text>().text = "2";
        allAbilityButtons[2].GetComponentInChildren<Text>().text = "3";
        allAbilityButtons[howManyAbilitys - 2].GetComponentInChildren<Text>().text = "Left";
        allAbilityButtons[howManyAbilitys - 1].GetComponentInChildren<Text>().text = "Right";

        //CHANGE ME FIGURE OUT WAY TO SET ID
        //Last time we left off we set the ID to each gameobject wheather this is useful SHRUG
        for (int i = 0; i < howManyAbilitys; i++)
        {
            allAbilityButtons[i].GetComponent<KeyBinding>().abilityButtonID = i;
        }

        foreach (var ability in allAbilityButtons)
        {
            ability.GetComponent<Spells>().currentSpell = Spells.Spell.NOSPELL;
        }

        Debug.Log(allAbilityButtons[4].GetComponent<KeyBinding>().abilityButtonID);
    }
}
