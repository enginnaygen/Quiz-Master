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

    public void IncrementCorrectAnswers() //bu method her çaðrýldýðýnda correct answer sayýsý 1 artýcak
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
        //return Mathf.RoundToInt(correctAnswers / questionSeen * 100); bu þekilde yapýnca 0 dönüyor. Sebebi de þu: iki integeri bölünce float bir deðer oluþuyor ve otomatik oraya 0 diyor. 100*0=0 oluyor. Bunu düzeltmek için bir deðeri castlemek yeterlidir.
        return Mathf.RoundToInt(correctAnswers /(float) questionSeen * 100);

    }
}
