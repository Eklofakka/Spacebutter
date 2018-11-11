using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class DrawPixelCircle
{
    public static Texture2D Drawd(int radius, Color clr, Texture2D texture)
    {
        //Texture2D texture = new Texture2D(radius * 2, ( radius * 2 ) + 2, TextureFormat.RGBA32, false, false);

        int x = texture.width / 2;
        int y = texture.height / 2;

        //var pxls = texture.GetPixels32();
        //for (int i = 0; i < pxls.Length; i++)
        //{
        //    pxls[i] = new Color32(0, 0, 0, 0);
        //}

        //texture.SetPixels32(pxls);

        DrawC(x, y, radius, texture, true, clr);

        //texture.filterMode = FilterMode.Point;

        texture.Apply();


        return texture;
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
}