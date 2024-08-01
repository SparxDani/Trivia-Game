using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerObjectMove : MonoBehaviour
{
    [SerializeField] int matchId;
    [SerializeField] ControllerBoxToPressAndMove controller;
    [SerializeField] RectTransform RectTransform;

    public void OnCLick()
    {
        controller.numberToContainer = matchId;
        Debug.Log(controller.numberToContainer);
        controller.Set_TransformToTheContainer(RectTransform);
        controller.Compare();
    }
}
