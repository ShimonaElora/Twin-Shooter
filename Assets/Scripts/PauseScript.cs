using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PauseScript : MonoBehaviour, IPointerClickHandler
{

    Button button;

    public GameObject panel;

    public TMP_Dropdown dropDown;

    public GameObject buttons;

    public GameObject joystick;

    //public TextMeshProUGUI textDropDown;

    private void Start()
    {
        button = GetComponent<Button>();
        dropDown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropDown);
        });
        if (PlayerPrefs.GetInt("input_type", 0) == 0)
        {
            buttons.SetActive(true);
            joystick.SetActive(false);
        }
        else
        {
            buttons.SetActive(false);
            joystick.SetActive(true);
        }
    }

    private void Update()
    {
        if (GameMechsScript.isPaused)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameMechsScript.isPaused = true;
        panel.SetActive(true);
        dropDown.value = PlayerPrefs.GetInt("input_type", 0);
    }

    void DropdownValueChanged(TMP_Dropdown change)
    {
        PlayerPrefs.SetInt("input_type", change.value);
        if (change.value == 0)
        {
            buttons.SetActive(true);
            joystick.SetActive(false);
        } else
        {
            buttons.SetActive(false);
            joystick.SetActive(true);
        }
    }
}
