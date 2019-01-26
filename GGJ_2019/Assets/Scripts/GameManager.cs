using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Menu,
        Playing,
        EndGame
    }

    [SerializeField] private UI m_UI;

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
            else if (gameState == GameState.Playing)
                EndGame();
        }
	}

    public void StartGame()
    {
        m_UI.DisplayGameCanvas();

        gameState = GameState.Playing;

        StartCoroutine(timer(timeToWait, TriggerSpawner));
    }

    public void EndGame()
    {
        m_UI.DisplayEndCanvas();

        gameState = GameState.EndGame;
    }

    public void TriggerSpawner()
    {
        int rdm = UnityEngine.Random.Range(0, windSpawners.Length - 1);

        windSpawners[rdm].Spawn();
    }

    private IEnumerator timer(float f, Action callback)
    {
        yield return new WaitForSeconds(f);

        timeToWait -= decrementTimeToWait;
        if (timeToWait < minTimetoWait)
            timeToWait = minTimetoWait;

        callback();

        nextMeteo = StartCoroutine(timer(timeToWait, TriggerSpawner));
    }
}
