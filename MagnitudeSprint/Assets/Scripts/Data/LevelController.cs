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
    public int XCounter = 1;

    private GameStatement _prevGameStatement;


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


    private void OnDisable()
    {
        Time.timeScale = 1;
    }


    public void StartGame()
    {
        GameStatement = GameStatement.GameOn;
        UIController.Instance.StartGame();
        ObstacleSpawner.SetActive(true);
        PlayerAnimation.Instance.Run();

        var player = FindObjectOfType<PlayerMovement>();
        player.enabled = true;
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
        Invoke("AddX", 0.7f);
        Invoke("ContinueFinishBarbell", 2.1f);
    }


    public void ContinueFinishBarbell()
    {
        FinishObstacle.Instance.Speed = 10;
        FinishObstacle.Instance.Stop = false;
        PlayerAnimation.Instance.Run();
    }


    public void AddX()
    {
        XCounter++;
        UIController.Instance.SetXText(XCounter);
    }


    public void Pause()
    {
        _prevGameStatement = GameStatement;
        GameStatement = GameStatement.GamePaused;
        UIController.Instance.Pause();
        Time.timeScale = 0;
    }


    public void UnPause()
    {
        GameStatement = _prevGameStatement;
        UIController.Instance.UnPause();
        Time.timeScale = 1;
    }


    public void PlayerLose()
    {
        _prevGameStatement = GameStatement;
        GameStatement = GameStatement.PlayerLose;
        PlayerAnimation.Instance.Fall();
        ObstacleSpawner.SetActive(false);

        var obstacles = FindObjectsOfType<Obstacle>();
        foreach (var obstacle in obstacles)
        {
            obstacle.Stop();
        }
        var finish = FindObjectOfType<FinishObstacle>();
        if (finish != null)
        {
            finish.Stop = true;
            finish.Speed = 0;
        }
        var player = FindObjectOfType<PlayerMovement>();
        player.enabled = false;

        UIController.Instance.PlayerLose();
    }


    public void GameOver()
    {
        _prevGameStatement = GameStatement;
        GameStatement = GameStatement.GameOver;
        PlayerAnimation.Instance.Fall();
        ObstacleSpawner.SetActive(false);

        var finish = FindObjectOfType<FinishObstacle>();
        if (finish != null)
        {
            finish.Stop = true;
            finish.Speed = 0;
        }
        var player = FindObjectOfType<PlayerMovement>();
        player.enabled = false;

        CoinCounter *= XCounter;
        UIController.Instance.GameOver(CoinCounter, XCounter);
    }


    public void ClaimAwards(int AdsX)
    {
        DataController.Instance.GameData.LevelCounter++;
        DataController.Instance.GameData.CoinCounter += CoinCounter * AdsX;
    }
}
