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

                GenerateTargetLine();


                //Image.raycastTarget = false;
                //Image.color = Color.white;
                break;
            case BodyTypes.SUN:
                //Image.sprite = Resources.Load<Sprite>(Assets.Sprites.SUN);

                //Image.color = Color.yellow;

                //SolarSystemBody target = ConstellationHandler.Constellation.SolarSystems[0].Planets[0];
                //int dist = (int)Vector2.Distance(Body.Position, target.Position) + 1;

                //Image.sprite = DrawPixelCircle.Drawd(dist, Color.white);

                GenerateSolarTexture();

                GetComponent<RectTransform>().sizeDelta = new Vector2( Image.sprite.rect.width, Image.sprite.rect.height );
                
                Image.color = new Color(1, 1, 1, 1f);

                Image.raycastTarget = false;

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
        int radius = (int)Vector2.Distance( planets[planets.Count - 1].Position, Body.Position ) + 1;
        
        Texture2D texture = new Texture2D(radius * 2, ( radius * 2 ) + 2, TextureFormat.RGBA32, false, false);

        texture.filterMode = FilterMode.Point;

        var pxls = texture.GetPixels32();
        for (int i = 0; i < pxls.Length; i++)
        {
            pxls[i] = new Color32(0, 0, 0, 0);
        }

        texture.SetPixels32(pxls);

        foreach (var planet in planets)
        {
            int r = (int)Vector2.Distance(planet.Position, Body.Position) + 1;
            texture = DrawPixelCircle.Drawd(r, Color.white, texture);
        }

        Image.sprite = Sprite.Create(texture, new Rect(0, 0, radius * 2, (radius * 2) + 2), Vector2.zero, 10, 0, SpriteMeshType.FullRect);
    }

    private void GenerateTargetLine()
    {
        GameObject pixelLine = DrawPixelLine.Line( Vector2.zero, Body.Position );

        pixelLine.transform.SetParent( transform, false );

        // Offset
        int xOffset = Body.Position.x < 0 ? 0 : 1;
        int yOffset = Body.Position.y < 0 ? 0 : 1;

        Texture2D texture = pixelLine.GetComponent<Image>().sprite.texture;

        pixelLine.transform.localPosition += new Vector3(0 - (xOffset * texture.width) , 0 - (yOffset * texture.height));
    }
}