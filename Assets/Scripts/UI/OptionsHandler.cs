using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsHandler : MonoBehaviour
{

    public void Confirm()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(Scenes.TITLE_SCREEN);
    }

    public void Cancel()
    {
        // fuck how do i invert this.
        SceneManager.LoadScene(Scenes.TITLE_SCREEN);
    }
}