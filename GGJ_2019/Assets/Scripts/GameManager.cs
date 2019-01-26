using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        Menu,
        Playing,
        EndGame
    }

    [SerializeField] private UI m_UI;
    [SerializeField] private Transform m_light;

    public GameState gameState;

    private Coroutine nextMeteo;

    public float timeToWait;
    public float decrementTimeToWait;
    public float minTimetoWait;

    public WindSpawner[] windSpawners;

    private void Start()
    {
        
        gameState = GameState.Menu;
    }

    void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameState == GameState.Menu)
                StartGame();
            else if (gameState == GameState.EndGame)
                StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gameState == GameState.Playing)
        {
            PauseGame();
        }
	}

    public void StartGame()
    {
        m_UI.DisplayGameCanvas();

        gameState = GameState.Playing;
        EnablePlayer(true);

        int rdm = UnityEngine.Random.Range(0, windSpawners.Length - 1);
        StartCoroutine(GoForNextMeteo(timeToWait, rdm, TriggerMeteo));
    }

    public void PauseGame()
    {
        m_UI.ShowHidePauseCanvas();
    }

    public void EnablePlayer(bool enabled)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerController>().IsActive = enabled;
        }
    }

    public void PlayerLost(PlayerController controller)
    {
        if (gameState == GameState.Playing)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        Debug.Log("end game.");

        m_UI.DisplayEndCanvas();

        gameState = GameState.EndGame;

        StopCoroutine(nextMeteo);

        EnablePlayer(false);

        StartCoroutine(Timer(2.0f, ReloadGame));
    }

    public void TriggerMeteo(int windSpawnerIndex)
    {
        windSpawners[windSpawnerIndex].Spawn();

        timeToWait -= decrementTimeToWait;
        if (timeToWait < minTimetoWait)
            timeToWait = minTimetoWait;

        int rdm = UnityEngine.Random.Range(0, windSpawners.Length - 1);
        nextMeteo = StartCoroutine(GoForNextMeteo(timeToWait, rdm, TriggerMeteo));
    }

    private void ReloadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private IEnumerator GoForNextMeteo(float t, int windSpawnerIndex, Action<int> callback)
    {
        Quaternion begin = m_light.rotation;
        Quaternion end = windSpawners[windSpawnerIndex].transform.rotation;

        for (float f = 0.0f; f < t; f += Time.deltaTime)
        {
            Quaternion tmp = Quaternion.Lerp(begin, end, f / t);
            m_light.rotation = tmp;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1.0f);

        callback(windSpawnerIndex);
    }

    private IEnumerator Timer(float t, Action callback)
    {
        yield return new WaitForSeconds(t);
        callback();
    }
}
