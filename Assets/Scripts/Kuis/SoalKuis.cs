using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SoalKuis : MonoBehaviour
{
    [SerializeField] private Button _jawabA;
    [SerializeField] private Button _jawabB;
    [SerializeField] private Button _jawabC;
    [SerializeField] private Button _jawabD;

    [SerializeField] private bool _isAnswerA;
    [SerializeField] private bool _isAnswerB;
    [SerializeField] private bool _isAnswerC;
    [SerializeField] private bool _isAnswerD;

    public delegate void NextQuestion(int score);
    public static event NextQuestion OnQuestionAnswered;

    private void OnEnable()
    {
        Reset();
    }

    private void Start()
    {
        _jawabA.onClick.AddListener(AnswerA);
        _jawabB.onClick.AddListener(AnswerB);
        _jawabC.onClick.AddListener(AnswerC);
        _jawabD.onClick.AddListener(AnswerD);
    }

    private void AnswerA()
    {
        if (_isAnswerA)
        {
            _jawabA.GetComponent<Image>().color = Color.green;
            _jawabB.GetComponent<Image>().color = Color.red;
            _jawabC.GetComponent<Image>().color = Color.red;
            _jawabD.GetComponent<Image>().color = Color.red;

            StartCoroutine(LoadQuestion(10));
        }
        else
        {
            if (_isAnswerB)
            {
                _jawabB.GetComponent<Image>().color = Color.green;
            }
            else
            {
                _jawabB.GetComponent<Image>().color = Color.red;
            }
            if (_isAnswerC)
            {
                _jawabC.GetComponent<Image>().color = Color.green;
            }
            else
            {
                _jawabC.GetComponent<Image>().color = Color.red;
            }
            if( _isAnswerD)
            {
                _jawabD.GetComponent<Image>().color = Color.green;
            }
            else
            {
                _jawabD.GetComponent<Image>().color = Color.red;
            }
            _jawabA.GetComponent<Image>().color = Color.red;

            StartCoroutine(LoadQuestion(0));
        }
    }

    private void AnswerB()
    {
        if (_isAnswerB)
        {
            _jawabA.GetComponent<Image>().color = Color.red;
            _jawabB.GetComponent<Image>().color = Color.green;
            _jawabC.GetComponent<Image>().color = Color.red;
            _jawabD.GetComponent<Image>().color = Color.red;

            StartCoroutine(LoadQuestion(10));
        }
        else
        {
            if (_isAnswerA)
            {
                _jawabA.GetComponent<Image>().color = Color.green;
            }
            else
            {
                _jawabA.GetComponent<Image>().color = Color.red;
            }
            if (_isAnswerC)
            {
                _jawabC.GetComponent<Image>().color = Color.green;
            }
            else
            {
                _jawabC.GetComponent<Image>().color = Color.red;
            }
            if (_isAnswerD)
            {
                _jawabD.GetComponent<Image>().color = Color.green;
            }
            else
            {
                _jawabD.GetComponent<Image>().color = Color.red;
            }
            _jawabB.GetComponent<Image>().color = Color.red;

            StartCoroutine(LoadQuestion(0));
        }
    }

    private void AnswerC()
    {
        if (_isAnswerC)
        {
            _jawabA.GetComponent<Image>().color = Color.red;
            _jawabB.GetComponent<Image>().color = Color.red;
            _jawabC.GetComponent<Image>().color = Color.green;
            _jawabD.GetComponent<Image>().color = Color.red;

            StartCoroutine(LoadQuestion(10));
        }
        else
        {
            if (_isAnswerA)
            {
                _jawabA.GetComponent<Image>().color = Color.green;
            }
            else
            {
                _jawabA.GetComponent<Image>().color = Color.red;
            }
            if (_isAnswerB)
            {
                _jawabB.GetComponent<Image>().color = Color.green;
            }
            else
            {
                _jawabB.GetComponent<Image>().color = Color.red;
            }
            if (_isAnswerD)
            {
                _jawabD.GetComponent<Image>().color = Color.green;
            }
            else
            {
                _jawabD.GetComponent<Image>().color = Color.red;
            }
            _jawabC.GetComponent<Image>().color = Color.red;

            StartCoroutine(LoadQuestion(0));
        }
    }

    private void AnswerD()
    {
        if (_isAnswerD)
        {
            _jawabA.GetComponent<Image>().color = Color.red;
            _jawabB.GetComponent<Image>().color = Color.red;
            _jawabC.GetComponent<Image>().color = Color.red;
            _jawabD.GetComponent<Image>().color = Color.green;

            StartCoroutine(LoadQuestion(10));
        }
        else
        {
            if (_isAnswerA)
            {
                _jawabA.GetComponent<Image>().color = Color.green;
            }
            else
            {
                _jawabA.GetComponent<Image>().color = Color.red;
            }
            if (_isAnswerB)
            {
                _jawabB.GetComponent<Image>().color = Color.green;
            }
            else
            {
                _jawabB.GetComponent<Image>().color = Color.red;
            }
            if (_isAnswerC)
            {
                _jawabC.GetComponent<Image>().color = Color.green;
            }
            else
            {
                _jawabC.GetComponent<Image>().color = Color.red;
            }
            _jawabD.GetComponent<Image>().color = Color.red;

            StartCoroutine(LoadQuestion(0));
        }
    }

    private IEnumerator LoadQuestion(int score)
    {
        _jawabA.interactable = false;
        _jawabB.interactable = false;
        _jawabC.interactable = false;
        _jawabD.interactable = false;
        yield return new WaitForSecondsRealtime(2);
        OnQuestionAnswered?.Invoke(score);
    }

    public void Reset()
    {
        _jawabA.interactable = true;
        _jawabB.interactable = true;
        _jawabC.interactable = true;
        _jawabD.interactable = true;

        _jawabA.GetComponent<Image>().color = Color.white;
        _jawabB.GetComponent<Image>().color = Color.white;
        _jawabC.GetComponent<Image>().color = Color.white;
        _jawabD.GetComponent<Image>().color = Color.white;
    }
}
