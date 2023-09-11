using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    [SerializeField] private List<GameObject> _listSoal = new List<GameObject>();
    [SerializeField] private List<GameObject> _listSoalSalah = new List<GameObject>();

    [SerializeField] private GameObject _scoreResultPanel;

    [SerializeField] private TextMeshProUGUI _finalScoreText;

    [SerializeField] private int _scoreSoal;
    [SerializeField] private int targetSoal;

    [SerializeField] private int _soalSekarang = 0;
    [SerializeField] private int counterSoal = 0;

    private bool usingPowerup = false;

    private void OnEnable()
    {
        Timer.OnGameOver += EndSession;
        SoalKuis.OnQuestionAnswered += RandomQuestion;

        _scoreSoal = 0;
        _soalSekarang = 0;
        counterSoal = 0;
        _scoreResultPanel.SetActive(false);
    }

    private void OnDisable()
    {
        Timer.OnGameOver -= EndSession;
        SoalKuis.OnQuestionAnswered -= RandomQuestion;
    }

    private void Start()
    {
        InitQuestion();
    }

    private void Update()
    {
        _finalScoreText.text = "Selamat " + SaveData.SaveInstance.CurrentUsername + " anda mendapat nilai " + _scoreSoal.ToString();
    }

    private void InitQuestion()
    {
        int randomSoalIndex = Random.Range(0, _listSoal.Count);

        _soalSekarang = randomSoalIndex;

        _listSoal[_soalSekarang].SetActive(true);

        counterSoal++;
    }

    private void RandomQuestion(int score)
    {
        _scoreSoal += score;

        if(usingPowerup)
        {
            _listSoalSalah[_soalSekarang].SetActive(false);
            _listSoalSalah.RemoveAt(_soalSekarang);

            InitQuestion();

            usingPowerup = false;
            return;
        }

        _listSoal[_soalSekarang].SetActive(false);

        if(score == 0)
        {
            _listSoalSalah.Add(_listSoal[_soalSekarang]);
        }

        _listSoal.RemoveAt(_soalSekarang);

        if (counterSoal == targetSoal)
        {
            _timer.StopTimer(_scoreSoal);
            SwitchPanel();
            return;
        }

        int randomSoalIndex = Random.Range(0, _listSoal.Count);

        _soalSekarang = randomSoalIndex;

        _listSoal[_soalSekarang].SetActive(true);

        counterSoal++;
    }

    public void SkipQuiz()
    {
        RandomQuestion(10);
    }

    public void ReanswerQuiz()
    {
        _listSoal[_soalSekarang].SetActive(false);

        int randomIndex = Random.Range(0, _listSoalSalah.Count);

        _soalSekarang = randomIndex;

        usingPowerup = true;

        _listSoalSalah[randomIndex].SetActive(true);
    }

    //private void NextQuestion(int score)
    //{
    //    _scoreSoal += score;

    //    _listSoal[_soalSekarang].SetActive(false);

    //    if (_soalSekarang == targetSoal)
    //    {
    //        _timer.StopTimer(_scoreSoal);
    //        SwitchPanel();
    //        return;
    //    }

    //    _soalSelanjutnya++;
    //    _listSoal[_soalSelanjutnya].SetActive(true);
    //    _soalSekarang++;
    //}

    private void SwitchPanel()
    {
        _scoreResultPanel.SetActive(true);
    }

    public void EndSession()
    {
        _timer.StopTimer(_scoreSoal);
        _listSoal[_soalSekarang].SetActive(false);
        SwitchPanel();
    }
}
