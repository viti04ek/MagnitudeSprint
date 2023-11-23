using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    public bool TestMod;

    private string _androidGameID = "5483513";
    private string _iOSGameID = "5483512";
    private string _gameID;


    private void Awake()
    {
        InitializeAds();
    }


    public void InitializeAds()
    {
        _gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSGameID : _androidGameID;
        Advertisement.Initialize(_gameID, TestMod, this);
    }


    public void OnInitializationComplete()
    {
        
    }


    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        
    }
}
