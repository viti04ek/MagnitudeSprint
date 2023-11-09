using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    public AudioList AudioList;
    public float SoundVolume;

    public AudioSource BGMusic;
    public float MusicVolume;


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
        SoundVolume = PlayerPrefs.GetFloat("SoundVolume", 1);
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);
        BGMusic.volume = MusicVolume;
    }


    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            PlayerPrefs.SetFloat("SoundVolume", SoundVolume);
            PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        }
    }


    private void OnDisable()
    {
        //PlayerPrefs.SetFloat("Volume", SoundVolume);
    }


    public void FindBGMusic()
    {
        BGMusic = GameObject.Find("BGMusic").GetComponent<AudioSource>();
        BGMusic.volume = MusicVolume;
    }


    public void BarbellSlap(Vector3 pos)
    {
        if (SoundVolume > 0)
            AudioSource.PlayClipAtPoint(AudioList.BarbellSlap, pos, SoundVolume);
    }


    public void BuyItem(Vector3 pos)
    {
        if (SoundVolume > 0)
            AudioSource.PlayClipAtPoint(AudioList.BuyItem, pos, SoundVolume);
    }


    public void CoinPickUp(Vector3 pos)
    {
        if (SoundVolume > 0)
            AudioSource.PlayClipAtPoint(AudioList.CoinPickUp, pos, SoundVolume);
    }


    public void EnemyHit(Vector3 pos)
    {
        if (SoundVolume > 0)
            AudioSource.PlayClipAtPoint(AudioList.EnemyHit, pos, SoundVolume);
    }


    public void GameOver(Vector3 pos)
    {
        if (SoundVolume > 0)
            AudioSource.PlayClipAtPoint(AudioList.GameOver, pos, SoundVolume);
    }


    public void LootPickUp(Vector3 pos)
    {
        if (SoundVolume > 0)
            AudioSource.PlayClipAtPoint(AudioList.LootPickUp, pos, SoundVolume);
    }


    public void PlayerFall(Vector3 pos)
    {
        if (SoundVolume > 0)
            AudioSource.PlayClipAtPoint(AudioList.PlayerFall, pos, SoundVolume);
    }


    public void PlayerLose(Vector3 pos)
    {
        if (SoundVolume > 0)
            AudioSource.PlayClipAtPoint(AudioList.PlayerLose, pos, SoundVolume);
    }


    public void ChangeMusicVolume(float volume)
    {
        MusicVolume = volume;
        BGMusic.volume = MusicVolume;
    }
}
