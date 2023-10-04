using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public GameObject GameOnUI;
    public GameObject PreStartUI;

    public Text CoinText;

    public GameObject PauseUI;
    public GameObject PlayerLoseUI;

    public Text XText;

    public GameObject GameOverUI;
    public Text FinishCoinsText;
    public Text AdsText;
    public Text ClaimText;

    public Text LvlText;
    public Text StartCoinCounter;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    private void Start()
    {
        LvlText.text = $"Level: {DataController.Instance.GameData.LevelCounter}";
        StartCoinCounter.text = DataController.Instance.GameData.CoinCounter.ToString();
    }


    public void StartGame()
    {
        PreStartUI.SetActive(false);
        GameOnUI.SetActive(true);
    }


    public void UpdateCoinText(int coin)
    {
        CoinText.text = coin.ToString();
    }


    public void Pause()
    {
        PauseUI.SetActive(true);
    }


    public void UnPause()
    {
        PauseUI.SetActive(false);
    }

    public void PlayerLose()
    {
        GameOnUI.SetActive(false);
        PlayerLoseUI.SetActive(true);
        AudioController.Instance.PlayerLose(Vector3.zero);
    }


    public void SetXText(int x)
    {
        XText.text = $"X{x}";
    }


    public void GameOver(int coins, int x)
    {
        GameOnUI.SetActive(false);
        GameOverUI.SetActive(true);
        AudioController.Instance.GameOver(Vector3.zero);

        FinishCoinsText.text = $"{coins / x} X{x}";
        AdsText.text = $"Claim {coins * 3}";
        ClaimText.text = $"Claim {coins}";
    }
}
