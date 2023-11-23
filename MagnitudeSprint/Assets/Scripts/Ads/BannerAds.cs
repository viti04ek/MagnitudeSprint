using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    public static BannerAds BannerAd;

    public BannerPosition BannerPosition;

    private string _androidAdUnityID = "Banner_Android";
    private string _iOSAdUnityID = "Banner_iOS";
    private string _adUnityID;


    private void Awake()
    {
        if (BannerAd == null)
            BannerAd = this;

        _adUnityID = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSAdUnityID : _androidAdUnityID;
    }


    private void Start()
    {
        Advertisement.Banner.SetPosition(BannerPosition);
        Invoke("LoadAd", 1);
    }


    public void LoadAd()
    {
        BannerLoadOptions bannerLoadOptions = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load(_adUnityID, bannerLoadOptions);
    }


    private void OnBannerLoaded()
    {
        //ShowAd();
    }


    private void OnBannerError(string message)
    {
        
    }


    public void ShowAd()
    {
        BannerOptions bannerOptions = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        Advertisement.Banner.Show(_adUnityID, bannerOptions);
    }


    private void OnBannerClicked()
    {

    }


    private void OnBannerHidden()
    {

    }


    private void OnBannerShown()
    {

    }


    public void HideAd()
    {
        Advertisement.Banner.Hide();
    }
}
