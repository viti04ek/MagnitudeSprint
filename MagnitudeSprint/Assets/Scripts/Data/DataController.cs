using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataController : MonoBehaviour
{
    public static DataController Instance = null;

    public int CoinCounter;
    public int LevelCounter;
    public SkinsData[] SkinsData;
    public HatsData[] HatsData;

    private BinaryFormatter _binaryFormatter;
    private string _dataFilePath;
}
