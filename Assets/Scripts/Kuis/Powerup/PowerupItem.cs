using UnityEngine;
using UnityEngine.UI;

public class PowerupItem : MonoBehaviour
{
    [field: SerializeField] public Powerup PowerupType { get; private set; }

    [SerializeField] private Timer timer;
    [SerializeField] private QuizManager quizManager;

    private Button initButton;

    public enum Powerup
    {
        SkipQuiz,
        TimerPlus,
        ReanswerWrongQuiz
    }

    private void Start()
    {
        initButton = GetComponent<Button>();

        initButton.onClick.AddListener(OnPowerupUsage);
    }

    public void OnPowerupUsage()
    {
        GameAudioManager.audioInstance.OnSoalHelp();
        
        switch (PowerupType)
        {
            case Powerup.SkipQuiz:
                quizManager.SkipQuiz();
                initButton.interactable = false;
                break;
            case Powerup.TimerPlus:
                timer.AddTimer();
                initButton.interactable = false;
                break;
            case Powerup.ReanswerWrongQuiz:
                quizManager.ReanswerQuiz();
                initButton.interactable = false;
                break;
        }
    }
}
