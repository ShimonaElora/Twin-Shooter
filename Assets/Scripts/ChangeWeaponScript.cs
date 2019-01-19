using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeWeaponScript : MonoBehaviour, IPointerClickHandler
{

    Button button;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameMechsScript.bulletNumber++;
    }
    
}
