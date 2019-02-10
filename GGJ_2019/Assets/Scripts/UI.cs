using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject m_StartCanvas;
    [SerializeField] private GameObject m_GameCanvas;
    [SerializeField] private GameObject m_PauseCanvas;
    [SerializeField] private GameObject m_EndCanvas;

    [Space]
    [SerializeField] private Text m_PlayerWinner;
    [SerializeField] private Text m_Score;

    [Space]
    [SerializeField] private Color m_OrangeColor;
    [SerializeField] private Color m_GreenColor;

    void Start ()
    {
	}

    public void ResetScreen()
    {
        m_GameCanvas.SetActive(false);
        m_PauseCanvas.SetActive(false);
        m_EndCanvas.SetActive(false);
    }

    public void DisplayGameCanvas()
    {
        m_StartCanvas.SetActive(false);

        m_GameCanvas.SetActive(true);
    }

    public void DisplayEndCanvas()
    {
        m_GameCanvas.SetActive(false);

        m_EndCanvas.SetActive(true);
    }

    public void ShowHidePauseCanvas()
    {
        m_PauseCanvas.SetActive(!m_PauseCanvas.activeSelf);
    }

    public void WinnerWinnerChickenDinner(Player player, string color)
    {
        m_PlayerWinner.text = color + " WON";
        if (player == Player.Player1)
            m_PlayerWinner.color = m_OrangeColor;
        else
            m_PlayerWinner.color = m_GreenColor;
    }

    public void SetScore(int orangeScore, int greenScore)
    {
        m_Score.text = orangeScore + " - " + greenScore;
    }
}
