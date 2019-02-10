using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePersistant : Singleton<GamePersistant>
{
    public int OrangeScore;
    public int GreenScore;

    private void Awake()
    {
        if (Instance != this)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    public void ResetScores()
    {
        OrangeScore = 0;
        GreenScore = 0;
    }
}
