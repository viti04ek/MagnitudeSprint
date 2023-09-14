using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject SkinPanel;
    public GameObject HatPanel;
    public GameObject SkinBtn;
    public GameObject HatBtn;
    public Sprite PressedBtn;
    public Sprite UnpressedBtn;


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
}
