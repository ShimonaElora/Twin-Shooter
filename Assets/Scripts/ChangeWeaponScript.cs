﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeWeaponScript : MonoBehaviour, IPointerClickHandler
{

    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (GameMechsScript.isPaused || GameMechsScript.isGameOver)
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
        GameMechsScript.bulletNumber++;
    }
    
}
