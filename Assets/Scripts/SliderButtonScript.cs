using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool isLeft;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isLeft)
        {
            PlayerScript.shouldMoveLeft = true;
        }
        else
        {
            PlayerScript.shouldMoveRight = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("here2");
        if (isLeft)
        {
            PlayerScript.shouldMoveLeft = false;
        }
        else
        {
            PlayerScript.shouldMoveRight = false;
        }
    }
}
