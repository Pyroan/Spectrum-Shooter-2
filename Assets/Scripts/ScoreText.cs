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
        text.text = "You lost, but you killed " + FindObjectOfType<GameManager>().GetScore() + " glowing balls, so I guess you have that going for you";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
