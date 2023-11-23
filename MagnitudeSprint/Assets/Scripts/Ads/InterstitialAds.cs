using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static InterstitialAds InterstitialAd;

    private string _androidAdUnityID = "Interstitial_Android";
    private string _iOSAdUnityID = "Interstitial_iOS";
    private string _adUnityID;


    private void Awake()
    {
        if (InterstitialAd == null)
            InterstitialAd = this;

        _adUnityID = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSAdUnityID : _androidAdUnityID;
        LoadAd();
    }


    public void LoadAd()
    {
        Advertisement.Load(_adUnityID, this);
    }


    public void ShowAd()
    {
        Advertisement.Show(_adUnityID, this);
    }


    public void OnUnityAdsAdLoaded(string placementId)
    {
        
    }


    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        
    }


    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        
    }


    public void OnUnityAdsShowStart(string placementId)
    {
        
    }


    public void OnUnityAdsShowClick(string placementId)
    {
        
    }


    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAd();
    }
}
