using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject StartCanvas;
    [SerializeField] private GameObject GameCanvas;
    [SerializeField] private GameObject PauseCanvas;
    [SerializeField] private GameObject EndCanvas;

    void Start ()
    {
        ResetScreen();
	}
	
	void Update ()
    {
		
	}

    public void ResetScreen()
    {
        GameCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
        EndCanvas.SetActive(false);

        StartCanvas.SetActive(true);
    }

    public void DisplayGameCanvas()
    {
        StartCanvas.SetActive(false);

        GameCanvas.SetActive(true);
    }

    public void DisplayEndCanvas()
    {
        GameCanvas.SetActive(false);

        EndCanvas.SetActive(true);
    }
}
