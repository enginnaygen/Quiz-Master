using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion; //soruyu yanýtlma süresi
    [SerializeField] float timeToShowCorrectAnswer; //doðru cevabý gösterme süresi

    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;  //soruya cevap veriliyor mu, yani hala cevap iþaretlenmedi
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

        if(isAnsweringQuestion)   //soruyu cevaplama sürecindeyse, henüz cevaplamadýysa
        {

            if(_timerValue>0)
            {
                fillFraction = _timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                _timerValue = timeToShowCorrectAnswer; //doðru cevabý gösterme süresini baþlat

            }
        }
        else     //doðru cevabý gösterme süresini baþladý
        {
            if (_timerValue > 0)
            {
                fillFraction = _timerValue / timeToShowCorrectAnswer;
            }
            else  //doðru cevabý gösterme süresi bitince diðer soruya geçmek için gerekli ortam saðlanýyor
            {
                isAnsweringQuestion = true;
                _timerValue = timeToCompleteQuestion;  //normal soru süresini baþlat
                loadNextQuestion = true;               //bir sonraki soruyu yükle
            }
        }
        //Debug.Log(isAnsweredQuestion+": "+ _timerValue +"= "+fillFraction);
    }
}
