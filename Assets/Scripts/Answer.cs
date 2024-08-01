using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    private Image image;
    [SerializeField]
    QuestionSetUp QuestionSetUp;
    [SerializeField] int correctAnswer;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void OnClick()
    {
        QuestionSetUp.SetImage(image);
        QuestionSetUp.correctAnswerChoice = correctAnswer;
        QuestionSetUp.Compare();
    }

}
