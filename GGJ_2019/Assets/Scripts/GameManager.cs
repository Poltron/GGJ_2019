﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        Playing,
        EndGame
    }

    [SerializeField] private PlayerController[] players;

    [SerializeField] private UI m_UI;
    [SerializeField] private Transform m_light;

    [SerializeField] private string[] sceneNames;

    [SerializeField]
    private GameObject m_EndRoundSFX;

    private StormSounds m_StormSounds;

    public GameState gameState;

    public bool SharedController = false;

    private Coroutine nextMeteo;

    public float timeBeforeTransition;
    public float transitionTime;
    public float staticTime;
    public float decrementStaticTime;
    public float minStaticTime;

    public WindSpawner[] windSpawners;

    private void Start()
    {
        m_StormSounds = m_light.gameObject.GetComponent<StormSounds>();

        StartGame();
    }

    private void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (gameState == GameState.EndGame)
            {
                Instantiate(m_EndRoundSFX);
                ReloadGame();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            if (gameState == GameState.EndGame)
            {
                Instantiate(m_EndRoundSFX);
                BackToMainMenu();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gameState == GameState.Playing)
        {
            if (Time.timeScale != 0)
                PauseGame();
            else
                UnpauseGame();
        }
	}

    private void StartGame()
    {
        gameState = GameState.Playing;
        EnablePlayer(true);

        int rdm = UnityEngine.Random.Range(0, windSpawners.Length - 1);
        StartCoroutine(GoForNextMeteo(transitionTime, rdm, TriggerMeteo));
    }

    public void PauseGame()
    {
        Time.timeScale = 0;

        m_UI.ShowHidePauseCanvas();
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;

        m_UI.ShowHidePauseCanvas();
    }

    private void BackToMainMenu()
    {
        GamePersistant.Instance.ResetScores();
        SceneManager.LoadScene("MainMenu");
    }

    private void EnablePlayer(bool enabled)
    {
        foreach (PlayerController player in players)
        {
            player.IsActive = enabled;
        }
    }

    public void PlayerLost(PlayerController controller)
    {
        if (gameState == GameState.Playing)
        {
            // player 1 lost
            if (controller.GetPlayerNumber() == Player.Player1)
            {
                m_UI.WinnerWinnerChickenDinner(Player.Player2, "GREEN");
                GamePersistant.Instance.GreenScore++;
            }
            // player 2 lost
            else
            {
                m_UI.WinnerWinnerChickenDinner(Player.Player1, "ORANGE");
                GamePersistant.Instance.OrangeScore++;
            }

            m_UI.SetScore(GamePersistant.Instance.OrangeScore, GamePersistant.Instance.GreenScore);
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("end game.");

        m_UI.DisplayEndCanvas();

        gameState = GameState.EndGame;

        StopCoroutine(nextMeteo);

        EnablePlayer(false);

        //StartCoroutine(Timer(2.0f, ReloadGame));
    }

    private void TriggerMeteo(int windSpawnerIndex)
    {
        windSpawners[windSpawnerIndex].Spawn();

        staticTime -= decrementStaticTime;
        if (staticTime < minStaticTime)
            staticTime = minStaticTime;

        int rdm = UnityEngine.Random.Range(0, windSpawners.Length - 1);
        if (rdm == windSpawnerIndex)
        {
            rdm--;
            if (rdm < 0)
                rdm = windSpawners.Length - 1;
        }

        nextMeteo = StartCoroutine(GoForNextMeteo(transitionTime, rdm, TriggerMeteo));
    }

    private void ReloadGame()
    {
        int rdm = UnityEngine.Random.Range(0, sceneNames.Length - 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNames[rdm]);
    }

    private IEnumerator GoForNextMeteo(float t, int windSpawnerIndex, Action<int> callback)
    {
        yield return new WaitForSeconds(timeBeforeTransition);

        Quaternion begin = m_light.rotation;
        Quaternion end = windSpawners[windSpawnerIndex].transform.rotation;

        m_StormSounds.PlayLightSwitchSound();

        for (float f = 0.0f; f < t; f += Time.deltaTime)
        {
            Quaternion tmp = Quaternion.Lerp(begin, end, f / t);
            m_light.rotation = tmp;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(staticTime - 2.5f);

        m_light.GetComponentInChildren<Animator>().SetTrigger("Alert");

        yield return new WaitForSeconds(1.5f);

        m_StormSounds.PlayThunderSound();

        yield return new WaitForSeconds(3f);

        m_StormSounds.PlayRainSound();

        yield return new WaitForSeconds(1.5f);

        callback(windSpawnerIndex);
    }

    private IEnumerator Timer(float t, Action callback)
    {
        yield return new WaitForSeconds(t);
        callback();
    }
}
