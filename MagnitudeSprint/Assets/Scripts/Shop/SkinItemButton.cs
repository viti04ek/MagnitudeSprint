using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinItemButton : MonoBehaviour
{
    public int ID;
    public GameObject Tick;
    public Sprite UnlockedSprite;
    public Image Image;
    public Text Text;
    public string Name;

    private bool _isUnlocked;
    private bool _isSelected;


    private void Start()
    {
        _isUnlocked = DataController.Instance.IsSkinUnlocked(ID);
        _isSelected = DataController.Instance.IsSkinSelected(ID);

        if (_isUnlocked)
        {
            Image.sprite = UnlockedSprite;
            Text.text = Name;
        }

        if (_isSelected)
        {
            Tick.SetActive(true);
        }
    }


    public void Click()
    {
        if (!_isUnlocked)
        {
            ShopController.Instance.TryToBuy(ID, true);
        }
        else if (!_isSelected)
        {
            Tick.SetActive(true);
            // дописать
        }
    }
}
