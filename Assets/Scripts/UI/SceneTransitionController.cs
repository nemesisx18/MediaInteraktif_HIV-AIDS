using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void OnTriggerSceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }
}
