using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Spawns enemies and tracks score
 */
public class GameManager : MonoBehaviour
{

    public Enemy /* heh */ enemyType;

    public float difficultyIncreaseInterval;
    public float difficultyIncreaseAmount;
    public float spawnRate;
    // Will only attempt to spawn whenever this interval passes.
    public float spawnInterval;
    public float spawnDistance;
    float nextSpawnChance;
    float nextDifficultyIncrease;
    int score;

    enum GameState
    {
        STARTING,
        ONGOING,
        OVER
    }
    GameState state;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        state = GameState.STARTING;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(Scenes.TITLE_SCREEN);
            Destroy(gameObject);
        }

        if (state == GameState.STARTING)
        {
            if (FindObjectOfType<Shield>().GetSpawned())
            {
                state = GameState.ONGOING;
                // Spawn the first enemy right away.
                Instantiate(enemyType,
                    Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward) * new Vector3(spawnDistance, 0, 0),
                    Quaternion.identity);
                nextSpawnChance = Time.time + spawnInterval;
                nextDifficultyIncrease = Time.time + difficultyIncreaseInterval;
            }
        }
        else if (state == GameState.ONGOING)
        {
            if (Time.time > nextSpawnChance)
            {
                if (Random.value > 1 - spawnRate)
                {
                    Instantiate(enemyType,
                        Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward) * new Vector3(spawnDistance, 0, 0),
                        Quaternion.identity);
                }
                nextSpawnChance = Time.time + spawnInterval;
            }

            if (Time.time > nextDifficultyIncrease)
            {
                spawnRate += difficultyIncreaseAmount;
                nextDifficultyIncrease = Time.time + difficultyIncreaseInterval;

            }
        }
        else if (state == GameState.OVER)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                SceneManager.LoadScene(Scenes.GAME);
                Destroy(gameObject);
            }
        }
    }

    public void IncrementScore()
    {
        // TODO: score based on how many hits it took to kill
        score++;

    }

    public int GetScore()
    {
        return score;
    }

    public void EndGame()
    {
        if (state == GameState.ONGOING)
        {
            state = GameState.OVER;
            StartCoroutine(LoadScoreScreen());
        }
    }

    IEnumerator LoadScoreScreen()
    {
        Camera.main.GetComponent<Animator>().SetTrigger("End Game");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(Scenes.SCORE_SCREEN);
    }
}
