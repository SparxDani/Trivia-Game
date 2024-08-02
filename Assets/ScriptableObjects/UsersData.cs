using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/User", order = 1)]
public class UsersData : ScriptableObject
{
    public int Id;
    public string Email;
    public string Password;
    public int Score;
}
