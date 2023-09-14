using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConfigData : MonoBehaviour
{
    public static ConfigData configInstance;

    public bool isBgmOn { get; private set; }
    public bool isSfxOn { get; private set; }

    private void Awake()
    {
        if (configInstance == null)
        {
            configInstance = this;
            Debug.Log(configInstance);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        LoadData();
        Debug.Log("BGM status: " + isBgmOn);
        Debug.Log("SFX status: " + isSfxOn);
    }

    [ContextMenu("Toggle BGM")]
    public void ToggleMusic()
    {
        isBgmOn = !isBgmOn;
        if (isBgmOn)
        {
            PlayerPrefs.SetInt("BGM", 1); //BGM on
        }
        else
        {
            PlayerPrefs.SetInt("BGM", 0); //BGM off
        }
        PlayerPrefs.Save();
        Debug.Log("BGM status: " + isBgmOn);
    }

    [ContextMenu("Toggle SFX")]
    public void ToggleEffect()
    {
        isSfxOn = !isSfxOn;
        if (isSfxOn)
        {
            PlayerPrefs.SetInt("SFX", 1); //SFX on
        }
        else
        {
            PlayerPrefs.SetInt("SFX", 0); //SFX off
        }
        PlayerPrefs.Save();
        Debug.Log("SFX status: " + isSfxOn);
    }

    private void LoadData()
    {
        int bgmDataHolder = PlayerPrefs.GetInt("BGM");
        if (bgmDataHolder == 1)
        {
            isBgmOn = true;
        }
        else
        {
            isBgmOn = false;
        }
        int sfxDataHolder = PlayerPrefs.GetInt("SFX");
        if (sfxDataHolder == 1)
        {
            isSfxOn = true;
        }
        else
        {
            isSfxOn = false;
        }
    }
}
