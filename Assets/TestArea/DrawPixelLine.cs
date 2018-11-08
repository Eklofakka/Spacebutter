using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DrawPixelLine
{
    public static Texture2D DrawLine(Texture2D texture, int x0, int y0, int x1, int y1, Color color, int gap = 0)
    {
        int dx = Mathf.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
        int dy = Mathf.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
        int err = (dx > dy ? dx : -dy) / 2, e2;

        int pc = 0;
        int flipX = x0 < x1 ? 1 : 0;
        int flipY = y0 < y1 ? 1 : 0;

        Debug.Log(flipX + " " + flipY);

        for (; ; )
        {
            if (pc == 0)
            {
                texture.SetPixel(x0, y0, Color.cyan);

            }
            else
            {
                texture.SetPixel(x0, y0, color);
            }
            //if (gap == 0 || pc % gap == 0)
            //{
            //    if ( (flipX == 1 && flipY == 0) || (flipX == 0 && flipY == 1))
            //    {
            //        texture.SetPixel(texture.width - x0 - 1, y0, color);
            //    }
            //    else
            //    {
            //        texture.SetPixel(x0, y0, color);
            //    }
            //}
            if (x0 == x1 && y0 == y1) break;
            e2 = err;
            if (e2 > -dx) { err -= dy; x0 += sx; }
            if (e2 < dy) { err += dx; y0 += sy; }

            pc++;
        }

        texture.Apply();

        return texture;
    }
}
