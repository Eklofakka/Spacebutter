using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Icon_Stargate : MonoBehaviour, IPointerClickHandler
{
    public Action<Icon_Stargate> OnClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick(this);
    }
}