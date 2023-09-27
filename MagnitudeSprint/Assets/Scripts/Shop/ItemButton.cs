using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public int ID;
    public GameObject Tick;
    public Sprite UnlockedSprite;
    public Image Image;
    public Text Text;
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
            Text.text = gameObject.name;
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
                Text.text = gameObject.name;
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
                Text.text = gameObject.name;
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

            if (IsSkin)
                DataController.Instance.SelectSkin(ID);
            else
                DataController.Instance.SelectHat(ID);
        }
        else if (_isSelected && !IsSkin)
        {
            Tick.SetActive(false);
            DataController.Instance.UnselectHat(ID);
        }
    }
}
