using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUsername : MonoBehaviour
{
    public InputField UserInputField;
    public GameObject NextScene;
    
    public string Username;

    private void Start()
    {
        GameAudioManager.audioInstance.PauseMusic();
        
        if(SaveData.SaveInstance.CurrentUsername != "")
        {
            NextScene.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void SubmitName()
    {
        SaveName(UserInputField.text);
        UserInputField.enabled = false;

        GameAudioManager.audioInstance.UnpauseMusic();
    }

    public void SaveName(string newName)
    {
        Username = newName;
        Debug.Log(Username);

        SaveData.SaveInstance.SetUsername(Username);
        NextScene.SetActive(true);
    }
}
