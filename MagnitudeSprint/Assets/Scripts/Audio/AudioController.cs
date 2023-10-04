using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    public AudioList AudioList;
    public float Volume;


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
    }


    private void OnEnable()
    {
        //Volume = PlayerPrefs.GetFloat("Volume", 1);
    }


    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            Volume = PlayerPrefs.GetFloat("Volume", 1);
    }


    private void OnDisable()
    {
        PlayerPrefs.SetFloat("Volume", Volume);
    }


    public void BarbellSlap(Vector3 pos)
    {
        if (Volume > 0)
            AudioSource.PlayClipAtPoint(AudioList.BarbellSlap, pos, Volume);
    }


    public void BuyItem(Vector3 pos)
    {
        if (Volume > 0)
            AudioSource.PlayClipAtPoint(AudioList.BuyItem, pos, Volume);
    }


    public void CoinPickUp(Vector3 pos)
    {
        if (Volume > 0)
            AudioSource.PlayClipAtPoint(AudioList.CoinPickUp, pos, Volume);
    }


    public void EnemyHit(Vector3 pos)
    {
        if (Volume > 0)
            AudioSource.PlayClipAtPoint(AudioList.EnemyHit, pos, Volume);
    }


    public void GameOver(Vector3 pos)
    {
        if (Volume > 0)
            AudioSource.PlayClipAtPoint(AudioList.GameOver, pos, Volume);
    }


    public void LootPickUp(Vector3 pos)
    {
        if (Volume > 0)
            AudioSource.PlayClipAtPoint(AudioList.LootPickUp, pos, Volume);
    }


    public void PlayerFall(Vector3 pos)
    {
        if (Volume > 0)
            AudioSource.PlayClipAtPoint(AudioList.PlayerFall, pos, Volume);
    }


    public void PlayerLose(Vector3 pos)
    {
        if (Volume > 0)
            AudioSource.PlayClipAtPoint(AudioList.PlayerLose, pos, Volume);
    }
}
