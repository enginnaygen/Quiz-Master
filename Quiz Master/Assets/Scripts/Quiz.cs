using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO _currentQuestion;


    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int _correctAnswerIndex;
    bool _hasAnsweredEarly=true;

    [Header("Button Colors")]
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite defaultSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer _timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper _scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;


    public bool isComplete;

    void Awake()
    {
        _timer = FindObjectOfType<Timer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    private void Update()
    {

        timerImage.fillAmount = _timer.fillFraction;
        if(_timer.loadNextQuestion)
        {

            if (progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;  //baska bir soru yüklememesi icin burdan donduruyoruz
            }
            _hasAnsweredEarly = false;
            GetNextQuestion();
            _timer.loadNextQuestion = false;

          
        }
        else if(!_hasAnsweredEarly && !_timer.isAnsweringQuestion) //süre bitti ve soru cevaplanmadýysa
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)  //butonlara verilen method
    {
        _hasAnsweredEarly = true;
        DisplayAnswer(index); //doðru þýkký iþaretle, cevao doðruysa soru texti correct!! yanlýþsa doðru cevabý yazdýrýyor
        SetButtonState(false);
        _timer.CancelTimer();
        scoreText.text = "Score: %" + _scoreKeeper.CalculatingScore();

        
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == _currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            _scoreKeeper.IncrementCorrectAnswers();

        }
        else
        {
            _correctAnswerIndex = _currentQuestion.GetCorrectAnswerIndex();
            string corrctAnswer = _currentQuestion.GetAnswer(_correctAnswerIndex);
            questionText.text = "Sorry, correct answer was:\n" + corrctAnswer;
            //questionText.text = "Sorry, correct answer: "+questionSO.GetAnswer(questionSO.GetCorrectAnswerIndex());

            //buttonImage = answerButtons[questionSO.GetCorrectAnswerIndex()].GetComponent<Image>();
            buttonImage = answerButtons[_correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        scoreText.text = "Score: %" + _scoreKeeper.CalculatingScore();

    }

    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetButtonDefaultSprite();
            GetRandomQuestion();
            DisplayQuestion();
            progressBar.value++;
            _scoreKeeper.IncrementQuestionSeen();

        }


    }

    private void GetRandomQuestion()
    {
        int index = UnityEngine.Random.Range(0, questions.Count);
        _currentQuestion = questions[index];

        if(questions.Contains(_currentQuestion))
        {
            questions.Remove(_currentQuestion);

        }
    }

    void DisplayQuestion()
    {
        questionText.text = _currentQuestion.GetQuestion(); //question texte data contanierdaki questioný ekliyoruz

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = _currentQuestion.GetAnswer(i);//butondaki texti data containerdeki text ile deðiþtiriyoruz 
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    void SetButtonDefaultSprite()
    {
        Image buttonImage;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultSprite;

        }
    }
}
