using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public float Delay;


    private void Start()
    {
        Invoke("LoadGameScene", Delay);
    }


    private void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
