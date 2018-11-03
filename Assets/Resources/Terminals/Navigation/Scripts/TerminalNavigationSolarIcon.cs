using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TerminalNavigationSolarIcon : MonoBehaviour, IPointerClickHandler
{
    public enum BodyTypes { STARGATE, SUN, PLANET }

    public Action<TerminalNavigationSolarIcon, PointerEventData> OnClick { get; set; } = delegate{};

    public SolarSystemBody Body;

    public BodyTypes BodyType;

    private Image Image;

    public void Init( SolarSystemBody body, BodyTypes bodyType )
    {
        Image = GetComponent<Image>();

        Body = body;

        BodyType = bodyType;

        switch (BodyType)
        {
            case BodyTypes.PLANET:
                Image.sprite = Resources.Load<Sprite>( Assets.Sprites.PLANET );
                break;
            case BodyTypes.STARGATE:
                GetComponent<RectTransform>().sizeDelta = new Vector2(8, 8);

                Image.sprite = Resources.Load<Sprite>(Assets.Sprites.STARGATE);

                Image.color = Color.white;
                break;
            case BodyTypes.SUN:
                Image.sprite = Resources.Load<Sprite>(Assets.Sprites.SUN);

                Image.color = Color.yellow;
                break;
        }

        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Body.Name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick(this, eventData);
    }

    private void OnDestroy()
    {
        OnClick = null;
    }
}