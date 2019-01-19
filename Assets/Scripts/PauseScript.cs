using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour, IPointerClickHandler
{

    Button button;

    public GameObject panel;

    private void Start()
    {
        button = GetComponent<Button>();
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
    }
}
