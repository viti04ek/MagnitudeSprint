using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameStatement
{ 
    GameNotStarted,
    GameOn,
    FinalPart,
    GameOver,
    PlayerLose,
    GamePaused
}


public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    public GameStatement GameStatement;
    public GameObject ObstacleSpawner;

    public int CoinCounter = 0;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    private void Update()
    {
        if (GameStatement == GameStatement.GameNotStarted)
        {

        }
        else if (GameStatement == GameStatement.GameOn)
        {

        }
        else if (GameStatement == GameStatement.FinalPart)
        {

        }
        else if (GameStatement == GameStatement.GameOver)
        {

        }
        else if (GameStatement == GameStatement.PlayerLose)
        {

        }
        else if (GameStatement == GameStatement.GamePaused)
        {

        }
    }


    public void StartGame()
    {
        GameStatement = GameStatement.GameOn;
        UIController.Instance.StartGame();
        ObstacleSpawner.SetActive(true);
        PlayerAnimation.Instance.Run();
    }


    public void AddCoin()
    {
        CoinCounter++;
        UIController.Instance.UpdateCoinText(CoinCounter);
    }


    public void OnFinish()
    {
        GameStatement = GameStatement.FinalPart;
    }


    public void StopFinishBarbell()
    {
        FinishObstacle.Instance.Speed = 0;
        FinishObstacle.Instance.Stop = true;
        PlayerAnimation.Instance.Smash();
        Invoke("ContinueFinishBarbell", 2.1f);
    }


    public void ContinueFinishBarbell()
    {
        FinishObstacle.Instance.Speed = 10;
        FinishObstacle.Instance.Stop = false;
        PlayerAnimation.Instance.Run();
    }
}
