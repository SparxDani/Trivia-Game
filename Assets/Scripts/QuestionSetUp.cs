using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class QuestionSetUp : MonoBehaviour
{
    [SerializeField]
    public int correctAnswerChoice;
    public int numberOfQuestion;
    private Image imageChoose;
    [SerializeField] ResultData result;
    public void Compare()
    {
        if (correctAnswerChoice != 0)
        {
            Debug.Log("Correct Answer");
            imageChoose.color = Color.green;
            result.correctAnswer++;
            GameController.nextLevel?.Invoke();
            //StartCoroutine(TransitionCorrectAnswer());
        }
        else
        {
            Debug.Log("Wrong Answer");
            imageChoose.color = Color.red;
            GameController.nextLevel?.Invoke();
            //StartCoroutine(TransitionIncorrectAnswer());
        }
    }
    //IEnumerator TransitionCorrectAnswer()
    //{
    //    yield return new WaitForSecondsRealtime(1.0f);
    //    imageChoose.color = Color.white;
    //    GameController.nextLevel?.Invoke();
    //}
    //IEnumerator TransitionIncorrectAnswer()
    //{
    //    yield return new WaitForSecondsRealtime(1.0f);
    //    imageChoose.color = Color.white;
    //}
    public void SetImage(Image imageBox)
    {
        imageChoose = imageBox;
    }

}
