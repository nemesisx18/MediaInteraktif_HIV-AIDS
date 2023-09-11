using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlocker : MonoBehaviour
{
    [SerializeField] private string unlockWord;
    [SerializeField] private string unlockWord2;
    [SerializeField] private string unlockWord3;
    [SerializeField] private string unlockWord4;
    [SerializeField] private string unlockWord5;
    [SerializeField] private string unlockWord6;
    [SerializeField] private string unlockWord7;
    [SerializeField] private string unlockWord8;

    [SerializeField] private bool isPencegahan = false;
    [SerializeField] private bool isPenularan = false;
    [SerializeField] private bool isLewat = false;
    [SerializeField] private bool isHubungan = false;
    [SerializeField] private bool isSekual = false;
    [SerializeField] private bool isVertikal = false;
    [SerializeField] private bool isIbkeBay = false;
    [SerializeField] private bool isDarha = false;

    [SerializeField] private Button pencegahan1;
    [SerializeField] private Button pencegahan2;
    [SerializeField] private Button pencegahan3;
    
    private void OnEnable()
    {
        Checker.OnConditionFullfiled += SetBoolStatus;
    }

    private void OnDisable()
    {
        Checker.OnConditionFullfiled -= SetBoolStatus;
    }

    private void SetBoolStatus(string data)
    {
        if(data == unlockWord)
        {
            isPencegahan = true;
        }

        if (data == unlockWord2)
        {
            isPenularan = true;
        }

        if (data == unlockWord3)
        {
            isLewat = true;
        }

        if (data == unlockWord4)
        {
            isHubungan = true;
        }

        if (data == unlockWord5)
        {
            isSekual = true;
        }

        if (data == unlockWord6)
        {
            isVertikal = true;
        }

        if (data == unlockWord7)
        {
            isIbkeBay = true;
        }

        if (data == unlockWord8)
        {
            isDarha = true;
        }
    }

    private void Update()
    {
        if(isPencegahan && isPenularan && isLewat && isHubungan && isSekual)
        {
            pencegahan1.interactable = true;
        }

        if(isPencegahan && isPenularan && isVertikal && isIbkeBay)
        {
            pencegahan2.interactable = true;
        }

        if(isPencegahan && isPenularan && isLewat && isDarha)
        {
            pencegahan3.interactable = true;
        }
    }
}
