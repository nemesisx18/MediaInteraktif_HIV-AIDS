using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoSkipper : MonoBehaviour
{
    [SerializeField] private float videoDuration;
    [SerializeField] private float narationDuration;

    [SerializeField] private GameObject mainCanvas;

    [SerializeField] private Button skipBtn;

    public void StartVideo()
    {
        StartCoroutine(CountdownVideo());
    }

    public IEnumerator CountdownVideo()
    {
        skipBtn = GetComponent<Button>();
        skipBtn.onClick.AddListener(OnSkipVideo);
        
        mainCanvas.SetActive(false);
        GameAudioManager.audioInstance.BgmSource.Pause();
        GameAudioManager.audioInstance.SfxSource.Pause();

        yield return new WaitForSeconds(videoDuration + 0.5f);
        SkipVideo();
    }

    public void OnSkipVideo()
    {
        GameAudioManager.audioInstance.OnButtonClip();
        SkipVideo();
    }

    private void SkipVideo()
    {
        gameObject.SetActive(false);
        mainCanvas.SetActive(true);

        mainCanvas.GetComponent<MainMenuUIScene>().StopAudioFor(narationDuration);

        GameAudioManager.audioInstance.BgmSource.Play();
        GameAudioManager.audioInstance.SfxSource.Play();
    }
}
