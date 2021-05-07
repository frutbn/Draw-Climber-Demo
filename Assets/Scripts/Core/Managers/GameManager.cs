using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Manager<GameManager>
{
    private bool isGameStarted = false;
    public bool GetIsGameStarted => isGameStarted;

    [SerializeField] private List<ResetPosition> resetPositions;

    private void Start()
    {
        ChangeGameSpeed(0f);
        LevelManager.Instance.OpenLevel(LevelManager.Instance.GetLevel);
    }

    public void ChangeGameSpeed(float gameSpeed)
    {
        Time.timeScale = gameSpeed;
    }

    public void StartGame()
    {
        isGameStarted = true;

        ChangeGameSpeed(1f);
    }

    public void ResetGame()
    {
        isGameStarted = false;

        ChangeGameSpeed(0f);

        foreach (ResetPosition reset in resetPositions)
        {
            reset.GoFirstPosition();
        }
    }
}