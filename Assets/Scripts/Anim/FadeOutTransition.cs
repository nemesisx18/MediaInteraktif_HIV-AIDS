using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutTransition : MonoBehaviour
{
    [SerializeField] private Animator animatorComp;
    [SerializeField] private GameObject panel;
    [SerializeField] private string animaName;
    
    public void StartFadingOut()
    {
        StartCoroutine(FadeOut(animatorComp, animaName, panel));
    }
    
    public IEnumerator FadeOut(Animator animator, string animName, GameObject panel)
    {
        animator.Play(animName);

        yield return new WaitForSeconds(1.2f);

        panel.SetActive(false);
    }
}
