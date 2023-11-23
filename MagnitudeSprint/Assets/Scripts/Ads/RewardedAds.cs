using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static RewardedAds RewardedAd;

    private string _androidAdUnityID = "Rewarded_Android";
    private string _iOSAdUnityID = "Rewarded_iOS";
    private string _adUnityID;


    private void Awake()
    {
        if (RewardedAd == null)
            RewardedAd = this;

        _adUnityID = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSAdUnityID : _androidAdUnityID;
    }


    private void Start()
    {
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
        if (placementId.Equals(_adUnityID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            // finish
        }

        LoadAd();
    }
}
