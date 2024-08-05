using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ResultController : MonoBehaviour
{
    [SerializeField] ResultData result;
    [SerializeField] UsersData users;
    [SerializeField] TMP_Text text;
    public void On_Click()
    {
        SceneManager.LoadScene("Menu");
    }
    private void Start()
    {
        text.text = "Puntuación: " + result.correctAnswer + "/" + result.maxQuestion;
        users.Score += result.correctAnswer;
        TestConnection.SetScore?.Invoke();
    }
}
