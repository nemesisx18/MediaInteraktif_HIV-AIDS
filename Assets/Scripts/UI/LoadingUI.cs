using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private Slider loadingBar;

    [SerializeField] private GameObject nextPanel;

    [SerializeField] private AudioSource bgmSource;

    private void Update()
    {
        bgmSource.mute = !ConfigData.configInstance.isBgmOn;

        loadingBar.value = Time.time;

        if(loadingBar.value == loadingBar.maxValue)
        {
            nextPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
