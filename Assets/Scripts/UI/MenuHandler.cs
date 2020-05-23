using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuHandler : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene(Scenes.TITLE_SCREEN);

    }
    /************************
     * Title Screen Buttons *
     ************************/
    public void StartGame(bool transition)
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            // Fun fact this isn't actually destroying the gm.
            // dude i have no idea what to do about this.
            Destroy(gm);
        }
        if (transition)
        {
            StartCoroutine(TransitionToGame());

        }
        else
        {
            SceneManager.LoadScene(Scenes.GAME);
        }

    }

    IEnumerator TransitionToGame()
    {
        GetComponentInChildren<Animator>().SetTrigger("Fade Out");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(Scenes.GAME);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(Scenes.INSTRUCTIONS);
    }
    public void Options()
    {
        SceneManager.LoadScene(Scenes.OPTIONS);
    }

    public void Credits()
    {
        SceneManager.LoadScene(Scenes.CREDITS);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
