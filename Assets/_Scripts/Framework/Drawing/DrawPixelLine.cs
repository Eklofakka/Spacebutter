using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class DrawPixelLine
{
    private static Texture2D DrawLine(Texture2D texture, int x0, int y0, int x1, int y1, Vector2 start, Vector2 end, Color color, int gap = 0)
    {
        int dx = Mathf.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
        int dy = Mathf.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
        int err = (dx > dy ? dx : -dy) / 2, e2;

        gap++;
        gap = Mathf.Max( 1, gap );

        int pc = 0;
        int flipX = start.x < end.x ? 1 : 0;
        int flipY = start.y < end.y ? 1 : 0;
        
        for (; ; )
        {
            if (gap == 0 || pc % gap == 0)
            {
                if (flipY == 1 && flipX == 0 || flipY == 0 && flipX == 1)
                {
                    texture.SetPixel(x0, y1 - y0, color);
                }
                else
                {
                    texture.SetPixel(x0, y0, color);
                }
            }

            if (x0 == x1 && y0 == y1) break;
            e2 = err;
            if (e2 > -dx) { err -= dy; x0 += sx; }
            if (e2 < dy) { err += dx; y0 += sy; }

            pc++;
        }

        texture.Apply();

        return texture;
    }

    public static GameObject Line( Vector2 start, Vector2 end )
    {
        int length = (int)Vector2.Distance( start, end );
        int width = Mathf.Max( (int)Mathf.Abs(start.x - end.x), 1 );
        int height = Mathf.Max( (int)Mathf.Abs(start.y - end.y), 1);

        GameObject obj = GetPixelLine();

        Texture2D texture = BlankTexture(width, height);

        texture = DrawLine(texture, 0, 0, Mathf.Max(width -1, 1), Mathf.Max(height -1, 1), start, end, Color.green);

        obj.GetComponent<Image>().sprite = CreateSprite( width, height, texture);

        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2( width, height );
        rectTransform.pivot = Vector2.zero;

        return obj;
    }

    private static GameObject GetPixelLine( )
    {
        GameObject line = new GameObject();

        line.AddComponent<RectTransform>();

        line.AddComponent<Image>();

        return line;
    }

    private static Texture2D BlankTexture(int width, int height)
    {
        Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, false, false);
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
        return Sprite.Create(texture, new Rect(0, 0, width, height), Vector2.zero, 10, 2, SpriteMeshType.Tight);
    }
}