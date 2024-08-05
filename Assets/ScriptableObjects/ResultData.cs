using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Result", order = 1)]
public class ResultData : ScriptableObject
{
    public int correctAnswer;
    public int maxQuestion;
    public bool register;
}
