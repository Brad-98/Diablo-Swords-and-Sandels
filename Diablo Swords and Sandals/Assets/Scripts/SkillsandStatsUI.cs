using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsandStatsUI : MonoBehaviour
{
    public GameObject skillsAndStatsWindow;

    public Text playerHealthText;
    public Text playerLevelText;
    public Text playerGoldText;

    public Slider experienceBar;
    

    void Start()
    {
        SetHealthText();

        experienceBar.maxValue = GameStats.instance.maxExperienceValue;
        experienceBar.value = GameStats.instance.currentExperienceValue;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            skillsAndStatsWindow.SetActive(!skillsAndStatsWindow.activeSelf);

            playerLevelText.text = "Level : " + GameStats.instance.playerLevel;
            playerGoldText.text = "Gold : " + GameStats.instance.playerGold;
        }

        if (experienceBar.value >= GameStats.instance.maxExperienceValue)
        {
            UpdateExperienceBarStats();
            GameStats.instance.playerLevel += 1;
        }
    }

    public void SetHealthText()
    {
        playerHealthText.text = "Health : " + GameStats.instance.playerHealth;
    }

    public void SetExperience(int experienceAmount)
    {
        GameStats.instance.currentExperienceValue += experienceAmount;
        experienceBar.value = GameStats.instance.currentExperienceValue;
    }

    private void UpdateExperienceBarStats()
    {
        GameStats.instance.currentExperienceValue -= GameStats.instance.maxExperienceValue; //Don't lose extra xp
        experienceBar.value = GameStats.instance.currentExperienceValue; //Reset the xp bar

        GameStats.instance.maxExperienceValue += GameStats.instance.playerLevel * GameStats.instance.playerLevel; //Calculate new max with linear formula

        experienceBar.maxValue = GameStats.instance.maxExperienceValue; //Set new max value
    }
}
