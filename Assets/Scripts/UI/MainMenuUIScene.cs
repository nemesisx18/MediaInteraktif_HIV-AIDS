using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIScene : MonoBehaviour
{
    [SerializeField] private Button[] everyButtons;
    
    [SerializeField] private string downloadGameLink;

    [Header("Config Audio")]
    [SerializeField] private Button toggleBGM;
    [SerializeField] private Button toggleSFX;
    [SerializeField] private Button toggleNotif;

    [SerializeField] private GameObject bgmChecker;
    [SerializeField] private GameObject sfxChecker;
    [SerializeField] private GameObject notifChecker;

    [SerializeField] private AudioSource bgmSource;

    private bool isNotif = false;

    private void Start()
    {
        for (int i = 0; i < everyButtons.Length; i++)
        {
            everyButtons[i].onClick.AddListener(GameAudioManager.audioInstance.OnButtonClip);
        }

        toggleBGM.onClick.AddListener(ChangeMusic);
        toggleSFX.onClick.AddListener(ChangeEffect);
        toggleNotif.onClick.AddListener(ChangeNotif);

        bgmChecker.SetActive(ConfigData.configInstance.isBgmOn);
        sfxChecker.SetActive(ConfigData.configInstance.isSfxOn);
        notifChecker.SetActive(isNotif);
    }

    private void Update()
    {
        bgmSource.mute = !ConfigData.configInstance.isBgmOn;
    }

    public void ShareToWhatsapp()
    {
        Application.OpenURL("https://api.whatsapp.com/send?text=" + downloadGameLink);
    }

    private void ChangeMusic()
    {
        ConfigData.configInstance.ToggleMusic();

        bgmChecker.SetActive(ConfigData.configInstance.isBgmOn);
    }

    private void ChangeEffect()
    {
        ConfigData.configInstance.ToggleEffect();

        sfxChecker.SetActive(ConfigData.configInstance.isSfxOn);
    }

    private void ChangeNotif()
    {
        isNotif = !isNotif;

        notifChecker.SetActive(isNotif);
    }
}
