using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager audioInstance;

    //[SerializeField] private ConfigData _configData;

    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioSource _bgmSoalSource;
    [SerializeField] private AudioSource _sfxSource;

    [SerializeField] private AudioClip menuBGM;
    [SerializeField] private AudioClip soalBGM;

    [SerializeField] private AudioClip buttonClickClip;
    [SerializeField] private AudioClip countdownClip;
    [SerializeField] private AudioClip soalHelpClip;
    [SerializeField] private AudioClip correctClip;
    [SerializeField] private AudioClip wrongClip;

    public AudioSource BgmSource => _bgmSource;
    public AudioSource SfxSource => _sfxSource;

    private bool isSoalMode = false;

    private void Awake()
    {
        if (audioInstance == null)
        {
            audioInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        _bgmSource.mute = !ConfigData.configInstance.isBgmOn;
        _sfxSource.mute = !ConfigData.configInstance.isSfxOn;
    }

    public void PauseMusic()
    {
        _bgmSource.Pause();
        _bgmSoalSource.Pause();
    }

    public void UnpauseMusic()
    {
        _bgmSource.Play();
        _bgmSoalSource.Play();
    }

    public void PlayMenuBGM()
    {
        _bgmSource.clip = menuBGM;
        _bgmSource.Play();
        _bgmSoalSource.Stop();
    }

    public void PlaySoalBGM()
    {
        _bgmSoalSource.clip = soalBGM;
        _bgmSoalSource.Play();
        _bgmSource.Stop();
    }

    public void ToggleSoalBool()
    {
        isSoalMode = !isSoalMode;
    }

    public void PlaySfx(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }

    public void OnButtonClip()
    {
        PlaySfx(buttonClickClip);
    }

    public void OnCorrectAnswer()
    {
        PlaySfx(correctClip);
    }

    public void OnWrongAnswer()
    {
        PlaySfx(wrongClip);
    }

    public void OnSoalHelp()
    {
        PlaySfx(soalHelpClip);
    }

    public void OnStartCountdown()
    {
        PlaySfx(countdownClip);
    }
}
