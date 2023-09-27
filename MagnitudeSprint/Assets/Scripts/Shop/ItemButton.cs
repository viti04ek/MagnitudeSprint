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
    public bool IsSkin;

    private bool _isUnlocked;
    private bool _isSelected;


    private void Start()
    {
        if (IsSkin)
        {
            _isUnlocked = DataController.Instance.IsSkinUnlocked(ID);
            _isSelected = DataController.Instance.IsSkinSelected(ID);
        }
        else
        {
            _isUnlocked = DataController.Instance.IsHatUnlocked(ID);
            _isSelected = DataController.Instance.IsHatSelected(ID);
        }

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


    private void Update()
    {
        if (IsSkin)
        {
            if (DataController.Instance.IsSkinUnlocked(ID) && !_isUnlocked)
            {
                _isUnlocked = DataController.Instance.IsSkinUnlocked(ID);
                Image.sprite = UnlockedSprite;
                Text.text = Name;
            }

            if (DataController.Instance.IsSkinSelected(ID) && !_isSelected)
            {
                _isSelected = DataController.Instance.IsSkinSelected(ID);
                Tick.SetActive(true);
            }

            if (!DataController.Instance.IsSkinSelected(ID) && _isSelected)
            {
                _isSelected = DataController.Instance.IsSkinSelected(ID);
                Tick.SetActive(false);
            }
        }
        else
        {
            if (DataController.Instance.IsHatUnlocked(ID) && !_isUnlocked)
            {
                _isUnlocked = DataController.Instance.IsHatUnlocked(ID);
                Image.sprite = UnlockedSprite;
                Text.text = Name;
            }

            if (DataController.Instance.IsHatSelected(ID) && !_isSelected)
            {
                _isSelected = DataController.Instance.IsHatSelected(ID);
                Tick.SetActive(true);
            }

            if (!DataController.Instance.IsHatSelected(ID) && _isSelected)
            {
                _isSelected = DataController.Instance.IsHatSelected(ID);
                Tick.SetActive(false);
            }
        }
    }


    public void Click()
    {
        if (!_isUnlocked)
        {
            ShopController.Instance.TryToBuy(ID, IsSkin);
        }
        else if (!_isSelected)
        {
            Tick.SetActive(true);
            // дописать
        }
    }
}
