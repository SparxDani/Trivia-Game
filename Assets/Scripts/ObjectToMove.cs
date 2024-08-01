using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToMove : MonoBehaviour
{
    [SerializeField] private int matchId;
    [SerializeField] Vector2 savePosition;
    [SerializeField] ControllerBoxToPressAndMove controller;
    [SerializeField] RectTransform rectTransform;
    public int Get_ID()
    {
        return matchId;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        savePosition = rectTransform.position;
        controller.numberToObjectMove = matchId;
        controller.Set_TransformToTheBox(rectTransform);
        controller.Set_OriginalPosition(savePosition);
        controller.Isinmoving = true;
    }
}
