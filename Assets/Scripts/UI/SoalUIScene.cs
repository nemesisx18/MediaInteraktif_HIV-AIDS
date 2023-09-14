using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoalUIScene : MonoBehaviour
{
    [SerializeField] private Button[] jawabButton;

    [SerializeField] private Button homeButton;

    private void Start()
    {
        for (int i = 0; i < jawabButton.Length; i++)
        {
            jawabButton[i].onClick.AddListener(GameAudioManager.audioInstance.OnButtonClip);
        }

        homeButton.onClick.AddListener(GameAudioManager.audioInstance.PlayMenuBGM);

        GameAudioManager.audioInstance.PlaySoalBGM();
        GameAudioManager.audioInstance.OnStartCountdown();
    }
}
