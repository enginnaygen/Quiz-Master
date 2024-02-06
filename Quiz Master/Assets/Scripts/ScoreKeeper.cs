using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int questionSeen = 0;

    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }

    public void IncrementCorrectAnswers() //bu method her �a�r�ld���nda correct answer say�s� 1 art�cak
    {
        correctAnswers++;
    }

    public int GetQuestionSeen()
    {
        return questionSeen;
    }

    public void IncrementQuestionSeen()
    {
        questionSeen++;
    }

    public int CalculatingScore()
    {
        //return Mathf.RoundToInt(correctAnswers / questionSeen * 100); bu �ekilde yap�nca 0 d�n�yor. Sebebi de �u: iki integeri b�l�nce float bir de�er olu�uyor ve otomatik oraya 0 diyor. 100*0=0 oluyor. Bunu d�zeltmek i�in bir de�eri castlemek yeterlidir.
        return Mathf.RoundToInt(correctAnswers /(float) questionSeen * 100);

    }
}
