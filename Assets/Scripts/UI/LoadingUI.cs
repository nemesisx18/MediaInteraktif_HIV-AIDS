using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private Slider loadingBar;

    [SerializeField] private GameObject nextPanel;

    private void Update()
    {
        loadingBar.value = Time.time;

        if(loadingBar.value == loadingBar.maxValue)
        {
            nextPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
