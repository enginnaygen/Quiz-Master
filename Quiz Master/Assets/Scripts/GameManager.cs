using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz _quiz;
    EndScreen _endScreen;

    private void Awake()
    {
        _quiz = FindObjectOfType<Quiz>();
        _endScreen = FindObjectOfType<EndScreen>();
    }

    private void Start()
    {
        _quiz.gameObject.SetActive(true);
        _endScreen.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(_quiz.isComplete)
        {
            _quiz.gameObject.SetActive(false);
            _endScreen.gameObject.SetActive(true);

            _endScreen.ShowFinalScore();
        }
    }


    public void ReStartGame()
    {
        SceneManager.LoadScene(0);
    }
}
