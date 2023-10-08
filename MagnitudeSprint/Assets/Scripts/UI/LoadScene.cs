using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadOtherScene(string scene)
    {
        ShowLoadingScreen();
        SceneManager.LoadScene(scene);
    }


    public void ReloadScene()
    {
        ShowLoadingScreen();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void ShowLoadingScreen()
    {
        if (UIController.Instance != null)
            UIController.Instance.ShowLoadingScreen();
        else if (ShopController.Instance != null)
            ShopController.Instance.ShowLoadingScreen();
    }
}
