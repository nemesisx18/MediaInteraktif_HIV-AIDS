using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager audioInstance;

    [SerializeField] private AudioSource _sfxSource;

    [SerializeField] private AudioClip menuBGM;
    [SerializeField] private AudioClip soalBGM;

    [SerializeField] private AudioClip buttonClickClip;
    [SerializeField] private AudioClip countdownClip;
    [SerializeField] private AudioClip soalHelpClip;
    [SerializeField] private AudioClip correctClip;
    [SerializeField] private AudioClip wrongClip;

    public AudioSource SfxSource => _sfxSource;

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
        _sfxSource.mute = !ConfigData.configInstance.isSfxOn;
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
