using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerBoxToPressAndMove : MonoBehaviour
{
    public bool Isinmoving = false;
    RectTransform boxSelected;
    RectTransform containerBox;
    [SerializeField] Canvas canvas;
    public int numberToObjectMove;
    public int numberToContainer;
    Vector2 originalPosition;
    private int numberOfCorrectAnswer;
    public int numberOfBoxPut;
    [SerializeField] ResultData result;
    public void Compare()
    {
        Isinmoving = false;
        if (numberToObjectMove == numberToContainer)
        {
            Debug.Log("Correct Form");
            boxSelected.position = containerBox.position;
            numberOfCorrectAnswer++;
            if (numberOfCorrectAnswer == 10)
            {
                Debug.Log("You Win");
                result.correctAnswer++;
                GameController.nextLevel?.Invoke();
            }
            if (numberOfBoxPut == 10)
            {
                GameController.nextLevel?.Invoke();
            }
            numberToObjectMove = 0;
            numberToContainer = 0;
        }
        else
        {
            Debug.Log("IncorrectForm");
            boxSelected.position = containerBox.position;
            if (numberOfBoxPut >= 10)
            {
                GameController.nextLevel?.Invoke();
            }
            //StartCoroutine(ResetBox());
        }

    }
    //IEnumerator ResetBox()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    boxSelected.position = originalPosition;
    //    numberToObjectMove = 0;
    //    numberToContainer = 0;
    //}
    public void Set_OriginalPosition(Vector2 boxPosition)
    {
        originalPosition = boxPosition;
    }
    public void Set_TransformToTheBox(RectTransform box)
    {
        boxSelected = box;
    }
    public void Set_TransformToTheContainer(RectTransform Containerbox)
    {
        containerBox = Containerbox;
    }
}
