using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<GameObject> obstaclePrefabs;

    [Space(10)]
    public Vector2 obstacleOffsetY = new Vector2(0, 0);
    public float obstacleInterval = 1f;
    public float obstacleSpeed = 10f;
    public float obstacleOffsetX = 0f;

    [HideInInspector]
    public int score = 0;

    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void EndGame()
    {
        isGameOver = true;

        StartCoroutine(ReloadScene(2));
    }

    public bool IsGameActive()
    {
        return !isGameOver;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    private IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        string sceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName);
    }
}