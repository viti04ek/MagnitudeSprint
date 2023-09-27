using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataController : MonoBehaviour
{
    public static DataController Instance = null;

    public GameData GameData;

    private BinaryFormatter BinaryFormatter;
    private string _dataFilePath;
    public bool DevMode;

    public Material PlayerMaterial;
    public GameObject PlayerHat;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        BinaryFormatter = new BinaryFormatter();
        _dataFilePath = Application.persistentDataPath + "/game.dat";
        Debug.Log(_dataFilePath);
    }


    private void Start()
    {
        foreach (var skin in GameData.SkinsData)
        {
            if (skin.IsSelected == true)
            {
                PlayerMaterial = skin.Material;
                break;
            }
        }

        foreach (var hat in GameData.HatsData)
        {
            if (hat.IsSelected == true)
            {
                PlayerHat = hat.Prefab;
                break;
            }
        }
    }


    public void RefreshData()
    {
        if (File.Exists(_dataFilePath))
        {
            FileStream fileStream = new FileStream(_dataFilePath, FileMode.Open);
            GameData = (GameData)BinaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            Debug.Log("Data refresh");
        }
    }


    private void OnEnable()
    {
        CheckDB();
    }


    private void OnDisable()
    {
        SaveData();
    }


    private void CheckDB()
    {
        if (!File.Exists(_dataFilePath))
        {
            #if UNITY_ANDROID
            CopyDB();
            #endif
        }
        else
        {
            if (SystemInfo.deviceType == DeviceType.Handheld && DevMode)
            {
                File.Delete(_dataFilePath);
                CopyDB();
            }

            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                string destFile = System.IO.Path.Combine(Application.streamingAssetsPath, "game.dat");
                File.Delete(destFile);
                File.Copy(_dataFilePath, destFile);
            }

            RefreshData();
        }
    }


    private void CopyDB()
    {
        string srcFile = System.IO.Path.Combine(Application.streamingAssetsPath, "game.dat");
        WWW downloader = new WWW(srcFile);
        while (!downloader.isDone)
        {

        }
        File.WriteAllBytes(_dataFilePath, downloader.bytes);
        RefreshData();
    }


    public void SaveData()
    {
        FileStream fileStream = new FileStream(_dataFilePath, FileMode.Create);
        BinaryFormatter.Serialize(fileStream, GameData);
        fileStream.Close();
        Debug.Log("Data saved");
    }


    public bool IsSkinUnlocked(int id)
    {
        return GameData.SkinsData[id].IsUnlocked;
    }


    public bool IsHatUnlocked(int id)
    {
        return GameData.HatsData[id].IsUnlocked;
    }


    public bool IsSkinSelected(int id)
    {
        return GameData.SkinsData[id].IsSelected;
    }


    public bool IsHatSelected(int id)
    {
        return GameData.HatsData[id].IsSelected;
    }


    public void BuySkin(int id)
    {
        GameData.CoinCounter -= GameData.SkinsData[id].Price;
        GameData.SkinsData[id].IsUnlocked = true;
    }


    public void BuyHat(int id)
    {
        GameData.CoinCounter -= GameData.HatsData[id].Price;
        GameData.HatsData[id].IsUnlocked = true;
    }


    public void SelectSkin(int id)
    {
        foreach (var skin in GameData.SkinsData)
        {
            skin.IsSelected = false;
        }

        GameData.SkinsData[id].IsSelected = true;
        PlayerMaterial = GameData.SkinsData[id].Material;
    }


    public void SelectHat(int id)
    {
        foreach (var hat in GameData.HatsData)
        {
            hat.IsSelected = false;
        }

        GameData.HatsData[id].IsSelected = true;
        PlayerHat = GameData.HatsData[id].Prefab;
    }


    public void UnselectHat(int id)
    {
        GameData.HatsData[id].IsSelected = false;
        PlayerHat = null;
    }
}
