using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class DrawPixelCircle
{
    public static GameObject Drawd(int radius, Color clr, bool doubleCenter = false)
    {
        //Texture2D texture = new Texture2D(radius * 2, ( radius * 2 ) + 2, TextureFormat.RGBA32, false, false);

        Texture2D texture = BlankTexture( radius * 2, radius * 2 );

        int width = radius * 2;

        int x = texture.width / 2;
        int y = texture.height / 2;

        //var pxls = texture.GetPixels32();
        //for (int i = 0; i < pxls.Length; i++)
        //{
        //    pxls[i] = new Color32(0, 0, 0, 0);
        //}

        //texture.SetPixels32(pxls);


        DrawC(x, y, radius, texture, doubleCenter, clr);

        //texture.filterMode = FilterMode.Point;

        texture.Apply();

        Sprite sprite = CreateSprite(width, width, texture);

        GameObject circ = new GameObject();

        Image image = circ.AddComponent<Image>();
        image.sprite = sprite;

        circ.GetComponent<RectTransform>().pivot = Vector2.zero;
        circ.GetComponent<RectTransform>().sizeDelta = new Vector2( width , width +1 );

        return circ;
        //return Sprite.Create(texture, new Rect(0, 0, radius * 2, (radius * 2) + 2), Vector2.zero, 10, 0, SpriteMeshType.FullRect);
    }

    private static void DrawC(int x0, int y0, int radius, Texture2D texture, bool doubleCenter, Color clr)
    {
        int x = radius - 1;
        int y = 0;
        int dx = 1;
        int dy = 1;
        int err = dx - (radius << 1);

        int dC = doubleCenter ? 1 : 0;

        while (x >= y)
        {
            texture.SetPixel(x0 + x, y0 + y + dC, clr);
            texture.SetPixel(x0 + y, y0 + x + dC, clr);

            texture.SetPixel(x0 - y - dC, y0 + x + dC, clr);
            texture.SetPixel(x0 - x - dC, y0 + y + dC, clr);

            texture.SetPixel(x0 - x - dC, y0 - y, clr);
            texture.SetPixel(x0 - y - dC, y0 - x, clr);

            texture.SetPixel(x0 + y, y0 - x, clr);
            texture.SetPixel(x0 + x, y0 - y, clr);

            if (err <= 0)
            {
                y++;
                err += dy;
                dy += 2;
            }

            if (err > 0)
            {
                x--;
                dx += 2;
                err += dx - (radius << 1);
            }
        }
    }

    private static Texture2D BlankTexture(int width, int height)
    {
        Texture2D texture = new Texture2D(width, height+1, TextureFormat.RGBA32, false, false);
        texture.filterMode = FilterMode.Point;

        var pxls = texture.GetPixels32();
        for (int i = 0; i < pxls.Length; i++)
        {
            pxls[i] = Color.clear;
        }

        texture.SetPixels32(pxls);
        texture.Apply();

        return texture;
    }

    private static Sprite CreateSprite(int width, int height, Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, width, height+1), Vector2.zero, 10, 2, SpriteMeshType.Tight);
    }
}