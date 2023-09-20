using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIScene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    [SerializeField] private Button[] buttonClicks;

    [SerializeField] private AudioSource bgmSource;

    private void Start()
    {
        for (int i = 0; i < buttonClicks.Length; i++)
        {
            buttonClicks[i].onClick.AddListener(GameAudioManager.audioInstance.OnButtonClip);
        }
    }

    private void Update()
    {
        bgmSource.mute = !ConfigData.configInstance.isBgmOn;
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
