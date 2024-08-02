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
    public static Action<bool> Register;
    private void Start()
    {
        result.correctAnswer = 0;
        result.maxQuestion=canvas.Length;
    }
    private void OnEnable()
    {
        nextLevel += IncrementIndex;
        Register += OnResgister;
    }
    private void OnDisable()
    {
        nextLevel -= IncrementIndex;
        Register -= OnResgister;

    }
    private void IncrementIndex()
    {

        quantity++;
        Debug.Log(quantity);
        if(quantity == 1&& result.register == false) 
        {
            SceneManager.LoadScene("Testing");
        }
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
    private void OnResgister(bool registrado)
    {
        result.register = registrado;
    }
}
