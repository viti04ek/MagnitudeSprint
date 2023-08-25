using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public GameObject PlayerStrength;
    public GameObject StartButton;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    public void StartGame()
    {
        StartButton.SetActive(false);
        PlayerStrength.SetActive(true);
    }
}
