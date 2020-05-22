using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(PreferenceKeys.CONTROL_HINTS, 1) == 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }

    }
}
