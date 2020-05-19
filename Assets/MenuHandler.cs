using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuHandler : MonoBehaviour
{

    Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void StartGame()
    {
        print("Um hello?");
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart()
    {
        animator.SetTrigger("Fade Out");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(1);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(0);
    }
    public void Options()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
