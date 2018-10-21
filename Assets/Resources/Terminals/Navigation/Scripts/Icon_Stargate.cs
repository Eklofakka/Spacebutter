using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Icon_Stargate : MonoBehaviour, IPointerClickHandler
{
    public Action<Icon_Stargate> OnClick;

    public Stargate Stargate;

    public void OnPointerClick(PointerEventData eventData)
    {
        if ( eventData.button == PointerEventData.InputButton.Left )
            OnClick(this);
    }

    private void OnDestroy()
    {
        OnClick = null;
    }
}