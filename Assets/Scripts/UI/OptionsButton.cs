using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButton : MenuButton
{

    public bool defaultValue = true;
    public string key;
    public string displayText;
    bool state;

    override protected void Start()
    {
        base.Start();
        SetState(PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1);
    }

    void SetState(bool state)
    {
        this.state = state;
        text.text = (state ? "[x] " : "[  ] ") + displayText;
        PlayerPrefs.SetInt(key, state ? 1 : 0);
    }

    public void Toggle()
    {
        SetState(!state);
    }

}
