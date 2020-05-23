using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EpilepsyScreen : MonoBehaviour
{
    public float timeOnscreen = 10f;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = FindObjectOfType<Animator>();
        StartCoroutine(Display());
    }

    IEnumerator Display()
    {
        yield return new WaitForSeconds(timeOnscreen);
        animator.SetTrigger("Fade Out");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(Scenes.TITLE_SCREEN);

    }
}
