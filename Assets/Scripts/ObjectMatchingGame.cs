using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(LineRenderer))]
public class ObjectMatchingGame : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private int matchId;
    //private bool isDragging;
    //private Vector3 endPoint;
    [SerializeField] SelectBox selectBox;
    public bool IsClicked;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }
    public void OnCLick()
    {
        if (IsClicked == false)
        {
            selectBox.Get_Button1(this.GetComponent<Image>());
            selectBox.numberToDraw = matchId;
            selectBox.DrawLine(lineRenderer);
            selectBox.numberOfBoxes++;
            IsClicked = true;
        }
        else
        {
            selectBox.Get_Button1(this.GetComponent<Image>());
            selectBox.numberToDraw = matchId;
            selectBox.DrawLine(lineRenderer);
        }
    }
}
