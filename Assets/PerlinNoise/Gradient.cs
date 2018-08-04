using System.Collections.Generic;
using UnityEngine;

namespace MyGradients
{
    public static class Gradient
    {
        public static Color32[] Create(int width, List<GradientColor> clrs)
        {
            int Width = width;

            CheckWidth(clrs, width);

            Color32[] Gradient = new Color32[Width];

            int startIndex = 0;
            foreach (var gradientColor in clrs)
            {
                LinearGradient(Gradient, gradientColor, startIndex, gradientColor.Width);

                startIndex += gradientColor.Width;
            }

            return Gradient;
        }

        public static Color32[] Create(int width, GradientColor clr)
        {
            List<GradientColor> clrs = new List<GradientColor>();
            clrs.Add(clr);

            return Create(width, clrs);
        }

        private static void LinearGradient(Color32[] gradient, GradientColor gradientClr, int startIndex, int width)
        {
            for (int i = 0; i < gradientClr.Width; i++)
            {
                int red = gradientClr.StartColor.r + ((gradientClr.EndColor.r - gradientClr.StartColor.r) * i / width);
                int green = gradientClr.StartColor.g + ((gradientClr.EndColor.g - gradientClr.StartColor.g) * i / width);
                int blue = gradientClr.StartColor.b + ((gradientClr.EndColor.b - gradientClr.StartColor.b) * i / width);
                int alpha = gradientClr.StartColor.a + ((gradientClr.EndColor.a - gradientClr.StartColor.a) * i / width);

                gradient[startIndex + i] = new Color32((byte)red, (byte)green, (byte)blue, (byte)alpha);
            }
        }

        private static void CheckWidth(List<GradientColor> clrs, int width)
        {
            int realWidth = 0;

            foreach (var clr in clrs)
            {
                realWidth += clr.Width;
            }

            if (realWidth != width)
                Debug.LogWarning("Gradients not matching widths: " + realWidth.ToString());
        }
    }

    [System.Serializable]
    public class GradientColor
    {
        public int Width;
        public Color32 StartColor = new Color32(255, 255, 255, 255);
        public Color32 EndColor = new Color32(255, 255, 255, 255);

        public GradientColor(int width, Color32 startClr, Color32 endClr)
        {
            Width = width;
            StartColor = startClr;
            EndColor = endClr;
        }
    }
}