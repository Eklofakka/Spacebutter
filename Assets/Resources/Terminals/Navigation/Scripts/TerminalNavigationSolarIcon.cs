using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TerminalNavigationSolarIcon : MonoBehaviour, IPointerClickHandler
{
    public enum BodyTypes { STARGATE, SUN, PLANET }

    public Action<TerminalNavigationSolarIcon> OnClick;

    public SolarSystemBody Body;

    public BodyTypes BodyType;

    public virtual void Init( BodyTypes bodyType )
    {
        BodyType = bodyType;
    }

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