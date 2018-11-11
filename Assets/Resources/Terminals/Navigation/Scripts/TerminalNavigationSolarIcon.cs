using System;
using System.Linq;
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
                Image.sprite = Assets.Sprites.Instance.SolarPlanet_8x8;
                break;
            case BodyTypes.STARGATE:
                GetComponent<RectTransform>().sizeDelta = new Vector2(8, 8);

                Image.sprite = Assets.Sprites.Instance.SolarStargate_8x8;

                GetComponent<RectTransform>().sizeDelta = new Vector2(Image.sprite.rect.width, Image.sprite.rect.height);

                Image.color = new Color(1, 1, 1, 1f);
                break;
            case BodyTypes.SUN:
                Image.sprite = Assets.Sprites.Instance.SolarPlanet_8x8;

                Image.color = Color.yellow;

                GenerateSolarTexture();

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

    private void GenerateSolarTexture()
    {
        List<Planet> planets = ConstellationHandler.Constellation.SolarSystems[0].Planets.OrderBy(p => (int)Vector2.Distance(p.Position, Body.Position)).ToList();
        int largestRadius = (int)Vector2.Distance( planets[planets.Count - 1].Position, Body.Position ) + 1;

        int[] radii = new int[planets.Count];
        for (int i = 0; i < planets.Count; i++)
        {
            radii[i] = (int)Vector2.Distance(planets[i].Position, Body.Position) + 1;
        }

        GameObject circles = DrawPixel.Circle.Draw(largestRadius, radii, new Color(1, 1, 1, 0.1f), true);
        circles.transform.SetParent( transform, false );

        Vector3 offset = circles.transform.localPosition;
        offset.x -= largestRadius;
        offset.y -= largestRadius + 1;
        circles.transform.localPosition = offset;
    }

    private void GenerateTargetLine()
    {
        // DONT DELETE CODE
        // USEFUL TEMPLATE

        GameObject pixelLine = DrawPixel.Line.Draw( Vector2.zero, Body.Position, Color.white );

        pixelLine.transform.SetParent( transform, false );

        // Offset
        int xOffset = Body.Position.x < 0 ? 0 : 1;
        int yOffset = Body.Position.y < 0 ? 0 : 1;

        Texture2D texture = pixelLine.GetComponent<Image>().sprite.texture;

        pixelLine.transform.localPosition += new Vector3(0 - (xOffset * texture.width) , 0 - (yOffset * texture.height));
    }
}