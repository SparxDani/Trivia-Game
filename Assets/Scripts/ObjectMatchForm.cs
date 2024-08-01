using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectMatchForm : MonoBehaviour
{
    [SerializeField] private int matchId;
    [SerializeField] SelectBox select;
    public int Get_ID()
    {
        return matchId;
    }
    public void OnClick()
    {
        select.Get_Button2(this.GetComponent<Image>());
        select.numberSelected = matchId;
        select.Compare();
    }
}
