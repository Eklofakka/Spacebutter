using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DrawPixel
{
    public static class Line
    {
        public static GameObject Draw(Vector2 start, Vector2 end, Color clr, int gap = 0)
        {
            int length = (int)Vector2.Distance(start, end);
            int width = Mathf.Max((int)Mathf.Abs(start.x - end.x), 1);
            int height = Mathf.Max((int)Mathf.Abs(start.y - end.y), 1);

            Texture2D texture = Utility.BlankTexture(width, height);

            texture = DrawLine(texture, 0, 0, Mathf.Max(width - 1, 1), Mathf.Max(height - 1, 1), start, end, clr, gap);

            SpriteRenderer obj = Utility.EmptyObject();
            //obj.raycastTarget = false;
            obj.sprite = Utility.CreateSprite(width, height, texture);

            RectTransform rectTransform = obj.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(width, height);
            rectTransform.pivot = Vector2.zero;

            return obj.gameObject;
        }

        private static Texture2D DrawLine(Texture2D texture, int x0, int y0, int x1, int y1, Vector2 start, Vector2 end, Color color, int gap = 0)
        {
            int dx = Mathf.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = Mathf.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = (dx > dy ? dx : -dy) / 2, e2;

            gap++;
            gap = Mathf.Max(1, gap);

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
    }

    public static class Circle
    {
        public static GameObject Draw(int radius, Color clr, bool doubleCenter = false)
        {
            Texture2D texture = Utility.BlankTexture(radius * 2, radius * 2);

            int width = radius * 2;

            int x = texture.width / 2;
            int y = texture.height / 2;


            DrawCircle(x, y, radius, texture, doubleCenter, clr);

            texture.Apply();

            Sprite sprite = Utility.CreateSprite(width, width, texture);

            GameObject circ = new GameObject();

            Image image = circ.AddComponent<Image>();
            image.sprite = sprite;

            circ.GetComponent<RectTransform>().pivot = Vector2.zero;
            circ.GetComponent<RectTransform>().sizeDelta = new Vector2(width, width + 1);

            return circ;
        }

        public static GameObject Draw( int largestRadius, int[] radii, Color clr, bool doubleCenter = false )
        {
            int fullWidth = largestRadius * 2;
            Texture2D texture = Utility.BlankTexture(fullWidth, fullWidth);
            int radius, width = 0;

            for (int i = 0; i < radii.Length; i++)
            {
                radius = radii[i];
                width = radius * 2;

                DrawCircle(largestRadius, largestRadius, radius, texture, doubleCenter, clr);
            }

            texture.Apply();

            Sprite sprite = Utility.CreateSprite(fullWidth, fullWidth, texture);

            SpriteRenderer circ = Utility.EmptyObject();
            circ.sprite = sprite;
            circ.gameObject.AddComponent<DragCamera>();

            CircleCollider2D col = circ.gameObject.AddComponent<CircleCollider2D>();
            col.isTrigger = true;

            return circ.gameObject;
        }

        private static void DrawCircle(int x0, int y0, int radius, Texture2D texture, bool doubleCenter, Color clr)
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

    public static class Utility
    {
        public static Texture2D BlankTexture(int width, int height)
        {
            Texture2D texture = new Texture2D(width, height + 1, TextureFormat.RGBA32, false, false);
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
        
        public static Sprite CreateSprite(int width, int height, Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0, 0, width, height + 1), Vector2.zero, 32, 2, SpriteMeshType.Tight);
        }

        public static SpriteRenderer EmptyObject()
        {
            return new GameObject().AddComponent<SpriteRenderer>();
        }
    }

    public static class Sprites
    {
        public static GameObject SolarSystemRings()
        {
            List<Planet> planets = ConstellationHandler.Constellation.SolarSystems[ShipHandler.Instance.ActiveShip.Position.SolarID].Planets.OrderBy(p => (int)Vector2.Distance(p.Position, Vector2.zero)).ToList();
            int largestRadius = (int)Vector2.Distance(planets[planets.Count - 1].Position, Vector2.zero) + 1;

            int[] radii = new int[planets.Count];
            for (int i = 0; i < planets.Count; i++)
            {
                radii[i] = (int)Vector2.Distance(planets[i].Position, Vector2.zero) + 1;
            }

            GameObject circles = DrawPixel.Circle.Draw(largestRadius, radii, new Color(1, 1, 1, 0.1f), true);

            Texture2D sprite = circles.GetComponent<SpriteRenderer>().sprite.texture;
            circles.transform.localPosition = new Vector3((sprite.width / 2f) / 32f, ((sprite.height + 1) / 2f) / 32, 0f) * -1;

            circles.name = "SolarSystemRingsTexture";

            return circles;
        }

        public static GameObject SolarSystemRings( Transform parent )
        {
            var circles = SolarSystemRings();

            circles.transform.SetParent(parent, false);

            return circles;
        }
    }
}