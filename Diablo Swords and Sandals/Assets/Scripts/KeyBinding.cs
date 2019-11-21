using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinding : MonoBehaviour
{
    public int abilityButtonID;
    public string keybind = "0";

    public void setKeyBinding(string keybindString, Input keybind)
    {
        Text keybindText = GetComponentInChildren<Text>();
        keybindText.text = keybindString;
    }
}
