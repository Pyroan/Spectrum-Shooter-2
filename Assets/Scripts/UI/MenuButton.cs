using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{

    Text text;
    public float offset;
    public bool hovering = false;
    // Use this for initialization
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hovering)
        {
            text.color = Color.HSVToRGB(((Time.time * 30 + offset) % 360) / 360, 1, 1);
        }
        else
        {
            text.color = Color.white;
        }
    }

    public void SetHover(bool set)
    {
        hovering = set;
    }
}
