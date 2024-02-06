using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion; //soruyu yan�tlma s�resi
    [SerializeField] float timeToShowCorrectAnswer; //do�ru cevab� g�sterme s�resi

    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;  //soruya cevap veriliyor mu, yani hala cevap i�aretlenmedi
    float _timerValue;
    public float fillFraction;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        _timerValue = 0;
    }

    void UpdateTimer()
    {
        _timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)   //soruyu cevaplama s�recindeyse, hen�z cevaplamad�ysa
        {

            if(_timerValue>0)
            {
                fillFraction = _timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                _timerValue = timeToShowCorrectAnswer; //do�ru cevab� g�sterme s�resini ba�lat

            }
        }
        else     //do�ru cevab� g�sterme s�resini ba�lad�
        {
            if (_timerValue > 0)
            {
                fillFraction = _timerValue / timeToShowCorrectAnswer;
            }
            else  //do�ru cevab� g�sterme s�resi bitince di�er soruya ge�mek i�in gerekli ortam sa�lan�yor
            {
                isAnsweringQuestion = true;
                _timerValue = timeToCompleteQuestion;  //normal soru s�resini ba�lat
                loadNextQuestion = true;               //bir sonraki soruyu y�kle
            }
        }
        //Debug.Log(isAnsweredQuestion+": "+ _timerValue +"= "+fillFraction);
    }
}
