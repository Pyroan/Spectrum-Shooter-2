using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public Text text;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null && gm.GetScore() > PlayerPrefs.GetInt(PreferenceKeys.HIGH_SCORE, 0))
        {
            PlayerPrefs.SetInt(PreferenceKeys.HIGH_SCORE, gm.GetScore());
        }

        if (gm.GetScore() > 249)
        {
            text.text = "You lost, but you killed <b>" + gm.GetScore() +
                        "</b> glowing balls, which is better than the developer's best score\n\nHigh Score: <b>" +
                        PlayerPrefs.GetInt(PreferenceKeys.HIGH_SCORE) + "</b>";
        }
        else
        {
            text.text = "You lost, but you killed <b>" + gm.GetScore() +
                        "</b> glowing balls, so I guess you have that going for you\n\nHigh Score: <b>" +
                        PlayerPrefs.GetInt(PreferenceKeys.HIGH_SCORE) + "</b>";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
