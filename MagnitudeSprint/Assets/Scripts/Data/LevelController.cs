using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


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

    public GameObject PlayerMesh;

    public LevelEnvironment[] LevelEnvironments;
    public GameObject Floor;
    public int LastEnvironment;
    public int CurrentEnvironment;

    public GameObject HatSpawn;

    public int AdsX = 1;

    private GameStatement _prevGameStatement;
    private bool _isLvlComplete = false;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    private void Start()
    {
        PlayerMesh.GetComponent<Renderer>().material = DataController.Instance.PlayerMaterial;

        CurrentEnvironment = PlayerPrefs.GetInt("CurrentEnvironment", -1);
        if (CurrentEnvironment >= 0)
        {
            PlayerPrefs.DeleteKey("CurrentEnvironment");
        }
        else
        {
            LastEnvironment = PlayerPrefs.GetInt("LastEnvironment", -1);
            do
            {
                CurrentEnvironment = Random.Range(0, LevelEnvironments.Length);

                if (LevelEnvironments[CurrentEnvironment].Skybox == null || LevelEnvironments[CurrentEnvironment].FloorMaterial == null || LevelEnvironments[CurrentEnvironment].FogColor == null)
                {
                    CurrentEnvironment = -1;
                    continue;
                }

                if (LastEnvironment < 0)
                    break;
            } while (CurrentEnvironment == LastEnvironment);
        }
        
        Floor.GetComponent<Renderer>().material = LevelEnvironments[CurrentEnvironment].FloorMaterial;
        RenderSettings.skybox = LevelEnvironments[CurrentEnvironment].Skybox;
        ColorUtility.TryParseHtmlString(LevelEnvironments[CurrentEnvironment].FogColor, out Color newFogColor);
        RenderSettings.fogColor = newFogColor;

        if (DataController.Instance.PlayerHat != null)
            Instantiate(DataController.Instance.PlayerHat, HatSpawn.transform.position, HatSpawn.transform.rotation, HatSpawn.transform);

        Time.timeScale = 1;

        Invoke("ShowBannerAd", 1.1f);
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

        if (!_isLvlComplete)
            PlayerPrefs.SetInt("CurrentEnvironment", CurrentEnvironment);
    }


    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            if (!_isLvlComplete)
                PlayerPrefs.SetInt("CurrentEnvironment", CurrentEnvironment);
        }
    }


    public void StartGame()
    {
        GameStatement = GameStatement.GameOn;
        UIController.Instance.StartGame();
        ObstacleSpawner.SetActive(true);
        PlayerAnimation.Instance.Run();

        var player = FindObjectOfType<PlayerMovement>();
        player.enabled = true;

        BannerAds.BannerAd.HideAd();
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
        AudioController.Instance.PlayerFall(Vector3.zero);
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

        ShowBannerAd();
    }


    public void GameOver()
    {
        _prevGameStatement = GameStatement;
        GameStatement = GameStatement.GameOver;
        PlayerAnimation.Instance.Fall();
        AudioController.Instance.PlayerFall(Vector3.zero);
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

        PlayerPrefs.SetInt("LastEnvironment", CurrentEnvironment);
        _isLvlComplete = true;

        ShowBannerAd();

        if (DataController.Instance.LevelsWithoutAds >= 3)
        {
            DataController.Instance.LevelsWithoutAds = 0;
            InterstitialAds.InterstitialAd.ShowAd();
        }
    }


    public void ClaimAwards()
    {
        DataController.Instance.GameData.LevelCounter++;
        DataController.Instance.GameData.CoinCounter += CoinCounter;
        DataController.Instance.LevelsWithoutAds++;
    }


    public void ClaimAdsAwards()
    {
        DataController.Instance.GameData.LevelCounter++;
        DataController.Instance.LevelsWithoutAds++;
        DataController.Instance.LevelsWithoutAds = 0;
        RewardedAds.RewardedAd.ShowAd();
    }


    public void ShowBannerAd()
    {
        BannerAds.BannerAd.ShowAd();
    }
}
