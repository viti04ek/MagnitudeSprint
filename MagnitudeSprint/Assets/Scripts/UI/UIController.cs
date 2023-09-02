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


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
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
    }


    public void SetXText(int x)
    {
        XText.text = $"X{x}";
    }


    public void GameOver()
    {
        GameOnUI.SetActive(false);
        GameOverUI.SetActive(true);
    }
}
