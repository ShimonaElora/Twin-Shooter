using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickScript : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image jsContainer;
    private Image joystick;

    public Vector3 InputDirection;

    // Start is called before the first frame update
    void Start()
    {
        jsContainer = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>(); //this command is used because there is only one child in hierarchy
        InputDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameMechsScript.isPaused && !GameMechsScript.isGameOver)
        {
            if (joystick.rectTransform.anchoredPosition.x > 0)
            {
                PlayerScript.shouldMoveRight = true;
                PlayerScript.shouldMoveLeft = false;
            }
            else if (joystick.rectTransform.anchoredPosition.x < 0)
            {
                PlayerScript.shouldMoveLeft = true;
                PlayerScript.shouldMoveRight = false;
            }
        }
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 position = Vector2.zero;

        //To get InputDirection
        RectTransformUtility.ScreenPointToLocalPointInRectangle
                (jsContainer.rectTransform,
                ped.position,
                ped.pressEventCamera,
                out position);

        position.x = (position.x / jsContainer.rectTransform.sizeDelta.x);
        position.y = (position.y / jsContainer.rectTransform.sizeDelta.y);

        float x = (jsContainer.rectTransform.pivot.x == 1f) ? position.x * 2 : position.x * 2;
        float y = (jsContainer.rectTransform.pivot.y == 1f) ? position.y * 2 : position.y * 2;

        InputDirection = new Vector3(x, y, 0);
        InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

        //to define the area in which joystick can move around
        if (!GameMechsScript.isPaused && !GameMechsScript.isGameOver)
        {
            joystick.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (jsContainer.rectTransform.sizeDelta.x / 3)
                                                               , InputDirection.y * (jsContainer.rectTransform.sizeDelta.y) / 3);
        } 
        else
        {
            InputDirection = Vector3.zero;
            joystick.rectTransform.anchoredPosition = Vector3.zero;
            PlayerScript.shouldMoveLeft = false;
            PlayerScript.shouldMoveRight = false;
        }

    }

    public void OnPointerDown(PointerEventData ped)
    {

        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {

        InputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
