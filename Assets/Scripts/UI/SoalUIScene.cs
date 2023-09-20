using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoalUIScene : MonoBehaviour
{
    [SerializeField] private Button[] jawabButton;

    [SerializeField] private AudioSource bgmSource;

    private void Start()
    {
        for (int i = 0; i < jawabButton.Length; i++)
        {
            jawabButton[i].onClick.AddListener(GameAudioManager.audioInstance.OnButtonClip);
        }

        GameAudioManager.audioInstance.OnStartCountdown();
    }

    private void Update()
    {
        bgmSource.mute = !ConfigData.configInstance.isBgmOn;
    }
}
