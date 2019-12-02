using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsandStatsUI : MonoBehaviour
{
    public GameObject skillsAndStatsWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            skillsAndStatsWindow.SetActive(!skillsAndStatsWindow.activeSelf);
        }
    }
}
