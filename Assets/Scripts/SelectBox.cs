using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class SelectBox : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public int numberToDraw;
    public int numberSelected;
    public bool isDragging;
    private Vector3 endPoint;
    private int numberOfCorrectAnswer;
    Image button1;
    Image button2;
    [SerializeField] ResultData result;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            lineRenderer.SetPosition(1, mousePosition);
            endPoint = mousePosition;
        }
    }
    public void DrawLine(LineRenderer renderer)
    {
        lineRenderer = renderer;
        isDragging = true;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        lineRenderer.SetPosition(0, mousePosition);
    }
    public void Get_Button1(Image button)
    {
        button1 = button;
    }
    public void Get_Button2(Image button)
    {
        button2 = button;
    }
    public void Compare()
    {
        isDragging = false;
        if (numberToDraw == numberSelected)
        {
            Debug.Log("Correct Form");
            button2.color = button1.color;
            numberOfCorrectAnswer++;
            if (numberOfCorrectAnswer == 4)
            {
                result.correctAnswer++;
                GameController.nextLevel?.Invoke();
            }
        }
        else
        {
            lineRenderer.positionCount = 0;
            numberToDraw = 0;
            numberSelected = 0;
        }
        lineRenderer.positionCount = 2;
    }
}
