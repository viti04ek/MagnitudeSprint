using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public static ShopController Instance;

    public GameObject SkinPanel;
    public GameObject HatPanel;
    public GameObject SkinBtn;
    public GameObject HatBtn;
    public Sprite PressedBtn;
    public Sprite UnpressedBtn;

    public GameObject BuyMenu;
    public Text PriceText;
    public int BuyItemID = -1;
    public bool IsItemSkin;

    public GameObject NoMoneyMenu;

    public Text CoinText;

    public GameObject LoadingScreen;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    private void Start()
    {
        UpdateCoinText();
    }


    public void UpdateCoinText()
    {
        CoinText.text = DataController.Instance.GameData.CoinCounter.ToString();
    }


    public void ShowSkin()
    {
        HatPanel.GetComponent<RectTransform>().DOAnchorPosX(Screen.width, 0.7f, false);
        SkinPanel.GetComponent<RectTransform>().DOAnchorPosX(0, 0.7f, false);
        SkinBtn.GetComponent<Image>().sprite = PressedBtn;
        HatBtn.GetComponent<Image>().sprite = UnpressedBtn;
    }


    public void ShowHat()
    {
        SkinPanel.GetComponent<RectTransform>().DOAnchorPosX(-Screen.width, 0.7f, false);
        HatPanel.GetComponent<RectTransform>().DOAnchorPosX(0, 0.7f, false);
        HatBtn.GetComponent<Image>().sprite = PressedBtn;
        SkinBtn.GetComponent<Image>().sprite = UnpressedBtn;
    }


    public void ShowBuyMenu()
    {
        BuyMenu.SetActive(true);
    }


    public void HideBuyMenu()
    {
        BuyMenu.SetActive(false);
        BuyItemID = -1;
    }


    public void ShowNoMoneyMenu()
    {
        NoMoneyMenu.SetActive(true);
    }


    public void HideNoMoneyMenu()
    {
        NoMoneyMenu.SetActive(false);
        BuyItemID = -1;
    }


    public void TryToBuy(int id, bool isSkin)
    {
        BuyItemID = id;
        IsItemSkin = isSkin;

        if (IsItemSkin && DataController.Instance.GameData.CoinCounter >= DataController.Instance.GameData.SkinsData[BuyItemID].Price)
        {
            PriceText.text = DataController.Instance.GameData.SkinsData[BuyItemID].Price.ToString();
            ShowBuyMenu();
        }
        else if (!IsItemSkin && DataController.Instance.GameData.CoinCounter >= DataController.Instance.GameData.HatsData[BuyItemID].Price)
        {
            PriceText.text = DataController.Instance.GameData.HatsData[BuyItemID].Price.ToString();
            ShowBuyMenu();
        }
        else
        {
            ShowNoMoneyMenu();
        }
    }


    public void Buy()
    {
        if (IsItemSkin)
            DataController.Instance.BuySkin(BuyItemID);
        else
            DataController.Instance.BuyHat(BuyItemID);

        AudioController.Instance.BuyItem(Vector3.zero);
        HideBuyMenu();
    }


    public void ShowLoadingScreen()
    {
        LoadingScreen.SetActive(true);
    }
}
