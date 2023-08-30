using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public GameObject GameOnUI;
    public GameObject StartButton;

    public Text CoinText;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    public void StartGame()
    {
        StartButton.SetActive(false);
        GameOnUI.SetActive(true);
    }


    public void UpdateCoinText(int coin)
    {
        CoinText.text = coin.ToString();
    }
}
