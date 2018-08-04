using UnityEngine;

namespace PlanetGen
{
    public static class PerlinGenerator
    {
        public static float[,] CalcNoise(int width, int height, int xOrigin, int yOrigin, float scale )
        {
            var Noise = new float[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float xCoord = xOrigin + (float)x / width * scale;
                    float yCoord = yOrigin + (float)y / height * scale;
                    float sample = Mathf.PerlinNoise(xCoord, yCoord);
                    Noise[x, y] = sample;
                }
            }

            return Noise;
        }
    }
}