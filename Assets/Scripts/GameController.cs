using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] Canvas[] canvas;
    public static Action nextLevel;
    public int quantity;
    [SerializeField] ResultData result;
    private void Start()
    {
        result.correctAnswer = 0;
        result.maxQuestion=canvas.Length;
    }
    private void OnEnable()
    {
        nextLevel += IncrementIndex;
    }
    private void OnDisable()
    {
        nextLevel -= IncrementIndex;
    }
    private void IncrementIndex()
    {

        quantity++;
        Debug.Log(quantity);
        if (quantity < canvas.Length)
        {
            canvas[quantity - 1].gameObject.SetActive(false);
            canvas[quantity].gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Result");
        }


    }
}
