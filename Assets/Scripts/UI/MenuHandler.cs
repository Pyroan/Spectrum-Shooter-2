using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuHandler : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene(0);

    }
    /************************
     * Title Screen Buttons *
     ************************/
    public void StartGame(bool transition)
    {
        if (transition)
        {
            StartCoroutine(TransitionToGame());

        }
        else
        {
            SceneManager.LoadScene(1);
        }

    }

    IEnumerator TransitionToGame()
    {
        GetComponentInChildren<Animator>().SetTrigger("Fade Out");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(1);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(3);
    }
    public void Options()
    {
        SceneManager.LoadScene(4);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
